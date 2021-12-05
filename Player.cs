using System.Collections;
using System.Collections.Generic;
using System;

namespace ImposterGameApp
{
    public class Player : State
    {
        Dictionary<string, State> States; 
        Stack<Room> RoomsVisited;
        Room _currentRoom;

        //Holds player's inventory
        BackPack backpack = new BackPack();

        //States Created. Added to dictionary for easy retrieval
        public void AddStates()
        {
            State STATE_SPEAKING = new State();
            State STATE_MOVING = new State();
            State STATE_LOST = new State();
            State STATE_WON = new State();

            States.Add("Moving", STATE_MOVING);
            States.Add("Speaking", STATE_SPEAKING);
            States.Add("Lost", STATE_LOST);
            States.Add("Won", STATE_WON);
        }

        //Retrive state from Dictionary of states based on key
        public State GetState(string stateName)
        {
            State state;
            States.TryGetValue(stateName, out state);
            return state;
        }

        //Set/Get Player's room
        public Room CurrentRoom
        {
            get
            {
                return _currentRoom;
            }
            set
            {
                _currentRoom = value;
            }
        }


        //Designated Constructor (initialize fields/State, populate data structures)
        public Player(Room room)
        {
            States = new Dictionary<string, State>();
            RoomsVisited = new Stack<Room>();

            _currentRoom = room;
            RoomsVisited.Push(_currentRoom);
            AddStates();

            //Initialize player state
            State initialState = GetState("Moving");
            Initialize(initialState);
        }

        //return to previous room
        public void WalkToPreviousRoom()
        {
            if (RoomsVisited.Count > 1)
            {
                _currentRoom = RoomsVisited.Pop();
                /*  foreach (Room room in RoomsVisited)
                  {
                      Console.WriteLine(room.Tag);
                  }*/

                Console.WriteLine("You are now " + _currentRoom.Tag + "\n" + _currentRoom.GetRoomObjects()  );
                //Name NPCs in current room
                this._currentRoom.NPCInRoom();
                

                Notification notification = new Notification("PlayerReturnToPreviousRoom", this);
                NotificationCenter.Instance.PostNotification(notification);
            }
            else {
                Console.WriteLine("I can't go back any further! ");
            }

        }

        //Controls player's mobility to different locations
        public void WalkTo(string direction)
        {
            Door door = this._currentRoom.GetExit(direction);
            if (door != null)
            {
                RoomsVisited.Push(this._currentRoom);
                Room nextRoom = door.OtherRoom(this._currentRoom);
                Notification notification = new Notification("PlayerWillExitRoom", this);
                NotificationCenter.Instance.PostNotification(notification);
                this._currentRoom = nextRoom;



                notification = new Notification("PlayerDidExitRoom", this);
                NotificationCenter.Instance.PostNotification(notification);
                this.OutputMessage("\n" + this._currentRoom.Description());
                //Name NPCs in current room
                this._currentRoom.NPCInRoom();
            }
            else
            {
                this.OutputMessage("\nThere is no door on " + direction);
            }
        }

        /*
         * public void Give(IItem item)
        {
            _inventory.Add(item);
        } //Add to room inventory or player's inventory


          public IItem Take(string itemName)
        {
            return inventory.RemoveItem(itemName);
        } //Take from room inventory or player's inventory
         */

        //Allows players to store valid objects in their inventory (backpack)
        public bool TakeRoomObject(string obj)
        {
            GameObject gameObj = CurrentRoom.GetRoomObject(obj);
            //Check if object is in room
            if (gameObj == null) //!CurrentRoom.ObjectInRoom(obj))
            {
                this.ErrorMessage("There's no sign of that in here!");
                return false;
            }

            else
            {
                //Find obj. in room list of objects
                //GameObject gameObj = CurrentRoom.GetRoomObject(obj);
                //Player can only carry a certain amount of weight
                if (backpack.BackPackWeight() + gameObj.Weight < backpack.maxCapacity && gameObj.Takeable)
                {
                    gameObj.Taken = true;

                    //Room object from room, gameObj.CurrentRoom.
                    CurrentRoom.roomObjects.Remove(obj);
                    this.OutputMessage("You now posess a " + obj);

                    //Add object to player inventory (backpak)
                    this.backpack.AddObject(gameObj);
                    return true;
                }

                else if (gameObj.Takeable == false)
                {
                    ErrorMessage("I cannot take that");
                    return false;
                }
                else
                {
                    this.ErrorMessage("You can't carry all of that!");
                    return false;
                }
            }
        }

        //Drops object from backpack/removes from player's inventory (backpack)
        public void DropRoomObject(string obj, Dictionary<string, GameObject> objects)
        {

            //notify player that they do not have that object
            if (!backpack.Contains(obj))
            {
                this.ErrorMessage("I do not possess " + obj);
            }

            else
            {
                //Retrieve object from inventory (backpack) //Make method (drop)
                GameObject gameObj = backpack.GetObject(obj);

                //add object to current room
                CurrentRoom.roomObjects.Add(obj, gameObj);
                //Remove object from inventory (backpack)
                backpack.RemoveObject(obj);
                //notify player that they have dropped the object
                this.OutputMessage("I have dropped " + obj);
            }
        }


        //Returns description of object if present in room
        public void Inspect(string itemName)
        {
            GameObject gameObject = CurrentRoom.GetRoomObject(itemName);
            //if game object not in room inventory
            if (gameObject == null)
            {
                this.ErrorMessage("There's no sign of that object here!");
            }
            else
            {
                this.OutputMessage(gameObject.Description);
            }
        }


        public void TalkTo(string nPC)
        {
            State state = GetState("Speaking");
          
            NPC speakingNPC = GameWorld.Instance.GetNPC(nPC);
            try
            {
                if (this.CurrentRoom.IsNPCInRoom(nPC))
                {
                   this.ChangeState(state);
                   speakingNPC.Talk();
                   Notification notification = new Notification("GameStateHasChanged: PlayerIsSpeaking", this);
                   NotificationCenter.Instance.PostNotification(notification);
                }
                else
                {
                    ErrorMessage("No sign of them here!");
                }
            }
            catch (System.NullReferenceException)
            {
                ErrorMessage("No sign of them here!");
            }

        }


        //Player State switches from moving state to won or lost based on attack accuracy 
        //Utilizes observer pattern to send notification to system of state change
        public void KillImposter(string imposter, string weapon)
        {
            State Won = GetState("Won");
            State Lost = GetState("Lost");
            State Moving = GetState("Moving");

            NPC allegedImposter = GameWorld.Instance.GetNPC(imposter);

            try
            {
                //check is player has "weapon" bug
                if (!backpack.Contains(weapon))
                {
                    ErrorMessage("I don't have that object!");
                    //Console.WriteLine(backpack.inventory.Keys);
                }

                else
                {
                    GameObject _weapon = backpack.GetObject(weapon);
                    try
                    {
                        if (CurrentRoom.IsNPCInRoom(imposter))//(CurrentRoom == allegedImposter.CurrentRoom)
                        {
                            if (allegedImposter.IsImposter() && _weapon.isWeapon)
                            {
                                Notification notification = new Notification("GameStateHasChanged: PlayerHasWon", this);
                                NotificationCenter.Instance.PostNotification(notification);
                                ChangeState(Won);
                            }
                        

                            else if (allegedImposter.IsImposter() && !_weapon.isWeapon)//or !Is Not Imposter && no weapon
                            {
                                this.ErrorMessage("I cannot use that as a weapon!");
                            }

                            else if (!allegedImposter.IsImposter() && _weapon.isWeapon)// Is Not Imposter && has weapon
                            {
                                Notification notification = new Notification("GameStateHasChanged: PlayerHasLost", this);
                                NotificationCenter.Instance.PostNotification(notification);
                                ChangeState(Lost);
                            }

                            else if (!allegedImposter.IsImposter() && !_weapon.isWeapon)//or Is Not Imposter && no weapon
                            {
                                this.ErrorMessage("I cannot use that as a weapon!");
                            }

                        }
                    else
                    {
                        this.ErrorMessage("No sign of them here!");
                    }
                }
                catch (System.NullReferenceException)
                {
                    this.ErrorMessage("No sign of them here!");
                }
            }
        }


        catch (System.NullReferenceException)
        {
            this.ErrorMessage("No sign of them here!");
            this.ChangeState(Moving);
        }
            
    } 
     
        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        //Control text color
        public void WinnerMessage(string message)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }
        public void LoserMessage(string message)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }

        public void ErrorMessage(string message)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }
    }
}


