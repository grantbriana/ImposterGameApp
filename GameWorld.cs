using System;
using System.Collections.Generic;
using System.Text;


//Observer
namespace ImposterGameApp
{
    class GameWorld
    {
        private static GameWorld _instance = null;
        Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        public List<NPC> NPCS = new List<NPC>();
        Random random = new Random();


        //Singleton Game Pattern
        public static GameWorld Instance
        {
            get
            {
                // Lazy Initializer
                if (_instance == null)
                {
                    _instance = new GameWorld();
                }
                return _instance;
            }
        }

        private Room _entrance;
        public Room Entrance { get { return _entrance; } }
        private Room _exit;
        private Room _magicRoom;
        public Room MagicRoom { get { return _magicRoom; } }
        private Room _entertainmentRoom;
        private Room _toEntertainmentRoom;


        private GameWorld()
        {
            CreateWorld();
        }


        private void CreateWorld()
        {
            //Imposter Game Rooms
            Room breakRoom = new Room("in the Break Room"); rooms.Add("BreakRoom", breakRoom);
            Room pilotRoom = new Room("in the Pilot Room"); rooms.Add("pilotRoom", pilotRoom);
            Room gearRoom = new Room("in the Gear Room"); rooms.Add("gearRoom", gearRoom);
            Room crewQuarters = new Room("in Crew Quarters"); rooms.Add("crewQuarters", crewQuarters);
            //Room voidOfSpace = new Room("in the Void of Space"); rooms.Add("voidOfSpace", voidOfSpace);
            Room meetingRoom = new Room("in the Meeting Room"); rooms.Add("meetingRoom", meetingRoom);
            Room cargoRoom = new Room("in the Break Room"); rooms.Add("cargoRoom", cargoRoom);

            //Rooms populated with objects/weapons
            breakRoom.AddRoomObject("spoon", "A silver dining utensil", 0.5, true); breakRoom.AddRoomWeapon("knife", "A pointy silver dining utensil. Makes a useful weapon", 0.5);
            breakRoom.AddRoomObject("fork", "A silver dining utensil", 0.5, true);
            pilotRoom.AddRoomObject("Camera","A security camera that views of a all rooms of the entire spaceship", 3, false);
            gearRoom.AddRoomWeapon("laser gun","", 5); gearRoom.AddRoomObject("shelves", "", 5, false);
            cargoRoom.AddRoomObject("cargo box", "", 1.5, false); cargoRoom.AddRoomObject("gloves", "", 1.5, false);
            crewQuarters.AddRoomObject("desk", "A surface for writing", 30, false); crewQuarters.AddRoomObject("chair", "", 1.5, true);
           // meetingRoom.AddRoomObject(, "",1.5, true); meetingRoom.AddRoomObject("Food", "",1.5, true);

            //Doors connected for navigating throughout game
            Door door = Door.connectRooms(breakRoom, cargoRoom, "west", "east");
            door = Door.connectRooms(breakRoom, pilotRoom, "west", "east");
            door = Door.connectRooms(pilotRoom, breakRoom, "south", "north");
            door = Door.connectRooms(gearRoom, crewQuarters, "west", "east");
            door = Door.connectRooms(crewQuarters, meetingRoom, "north", "south");
            door = Door.connectRooms(meetingRoom, breakRoom, "south", "north");

            NPC blueNPC = new NPC("blue",true, pilotRoom); blueNPC.SetHint("I am not an imposter."); NPCS.Add(blueNPC); 
            NPC redNPC = new NPC("red", false, breakRoom); redNPC.SetHint("I think the imposter is manning our spaceship."); NPCS.Add(redNPC);
            NPC yellowNPC = new NPC("yellow", false, meetingRoom); yellowNPC.SetHint("I don't know who the imposter is, but you need a weapon to defeat them"); NPCS.Add(yellowNPC);
            NPC greenNPC = new NPC("green", false, cargoRoom); greenNPC.SetHint("Blue seems suspicious..."); NPCS.Add(greenNPC);

            //NPC OtherBlueNPC = blueNPC.Clone(breakRoom, "TheOtherBlue");
            //blue NPC's clone
            NPCS.Add(blueNPC.Clone(breakRoom, "TheOtherBlue"));

            //All NPC move to random rooms
           // MoveNPC();


            _entrance = crewQuarters;
            
            _exit = meetingRoom;
        }

        public NPC GetNPC(string _nPC)
        {
            NPC theNPC = null;
            foreach (NPC foundplayer in NPCS)
            {
                if (_nPC.Equals(foundplayer.Name)){
                    theNPC = foundplayer;
                }
               
            }
            return theNPC;
        }

        public Room GetRoom(string room)
        {
            rooms.TryGetValue(room, out Room room1);
            return room1;
        }

        //Moves NPC to random room
        public void MoveNPC()
        {
            List<Room> Rooms = new List<Room>(rooms.Values);
            int room = random.Next(rooms.Count); 
            foreach (NPC nPC in NPCS)
            {
                //nPC.CurrentRoom() = Rooms[room];
                nPC.SetCurrentRoom(Rooms[room]);
            }
        }

        
    }
}



