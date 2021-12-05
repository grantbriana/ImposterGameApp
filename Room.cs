using System.Collections;
using System.Collections.Generic;
using System;

namespace ImposterGameApp
{
    public class Room
    {
        private Dictionary<string, Door> exits;

        //Dictionary of Room objects
        public Dictionary<string, GameObject> roomObjects;

        List<NPC> roomNPCs;


        private string _tag;
        private string _LongDescription;
        public string Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public Room() : this("No Tag","No Description")
        {

        }


        //Designated Constructor
        public Room(string tag, string longDescription)
        {
            exits = new Dictionary<string, Door>();
            roomObjects = new Dictionary<string, GameObject>();
            roomNPCs = new List<NPC>();
            _LongDescription = longDescription;
            this.Tag = tag;
        }

        public void SetExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }


        public Door GetExit(string exitName)
        {
            Door door = null;
            exits.TryGetValue(exitName, out door);
            return door;
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Door>.KeyCollection keys = exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }

        //Method to create game objects 
        public bool AddRoomObject(string name, string description, double weight, bool takeable)
        {
            GameObject objectName = new GameObject(name, description, weight, takeable);
            roomObjects.Add(name, objectName);
            return true;
        }

        //Method to create weapon objects 
        public bool AddRoomWeapon(string name, string description, double weight)
        {
            Weapon objectName = new Weapon(name, description, weight);
            roomObjects.Add(name, objectName);
            return true;
        }

        //Retrieve & return game object dictionary
        public string GetRoomObjects()
        {
            string objectNames = "Objects: ";
            Dictionary<string, GameObject>.KeyCollection keys = roomObjects.Keys;
            foreach (string objectName in keys)
            {
                objectNames += " " + objectName;
            }
            return objectNames;
        }

        public GameObject GetRoomObject(string obj)
        {
            GameObject gameObject;
            roomObjects.TryGetValue(obj, out gameObject);
            return gameObject;
        }

        //check if the given object name is in current room and taken
        public bool ObjectInRoom(string obj)
        {
            GameObject gameObject = GetRoomObject(obj);

            if (gameObject != null) {

                if (!gameObject.IsObjectTaken())
                {
                    return true;
                }
            }

            return false;
        }

        //check if NPC in room
        public string NPCInRoom()
        {
            string presentNPC = "";
            //NPC nPC = null;
            if (roomNPCs.Count > 0)
            {
                foreach (NPC npc in roomNPCs)
                {
                     presentNPC = npc.Name + " is present " + _tag;
                }
            }
            else
            {
                presentNPC = "No one is here" ;
            }
            return presentNPC;
        }

        public bool IsNPCInRoom(string nPC)
        {
            //NPC nPC = null;
            if (roomNPCs.Count > 0)
            {
                foreach (NPC npc in roomNPCs)
                {
                    if (npc.Name.Equals(nPC))
                    {
                        return true;
                    }
                }
            }
           return false;
        }

    /*  public NPC GetNPC(string _nPC)
        {
            NPC theNPC = null;
            foreach (NPC foundplayer in roomNPCs)
            {
                if (_nPC.Equals(foundplayer.Name))
                {
                    theNPC = foundplayer;
                }

            }
            Console.WriteLine(theNPC.Name);
            return theNPC;
        }*/


        //Add NPC to room
        public void AddNPC(NPC npc)
        {
            roomNPCs.Add(npc);
        }

        public string LongDescription()
        {
            return _LongDescription;
        }
    
        public string Description()
        {
            return "You are " + this.Tag + this.LongDescription() + ".\n *** " + this.GetExits() + "\n"
                   + "\nThis room contains " + this.GetRoomObjects() + "\n" + this.NPCInRoom();
            
        }

    }
}

