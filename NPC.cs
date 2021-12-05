using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    //prototype game pattern
     public class NPC
    {
        //virtual NPC* clone() = 0;
        public string Name { get; set; }
        private string Hint { get; set; }
        private bool _IsImposter;
        private Room _currentRoom;
        private bool scriptRan = false;


        public NPC(string name, bool IsImposter, Room room) 
        { 
            Name = name;
            _IsImposter = IsImposter;
            _currentRoom = room;
            _currentRoom.AddNPC(this);
        }

        public bool IsImposter()
        { 
           return _IsImposter;
        }

        public void SetHint(string _Hint)
        {
            Hint = _Hint;
            
            //if 1.

        }

        public string GetHint()
        {
            return Hint;
        }


        public void SetCurrentRoom(Room room)
        {
            _currentRoom = room;
            //return _currentRoom;
        }

        public void Talk()
        {
            if (scriptRan == false)
            {
                NPCMessage("\n" + Name + " >> " + "Hello");
                 
                Console.WriteLine("You >> 1. Ignore  2. Tell me everything you know.");

                //player's input
                //int response = Convert.ToInt32(Console.ReadLine());
                string response = Console.ReadLine();
                if (response.Equals("2")) // == 2)
                {
                    NPCMessage("\n" + Name + " >> " + GetHint());
                    scriptRan = true;
                }
                else if(!response.Equals("2") && !response.Equals("1"))
                {
                    NPCMessage("\n" + Name + " >> " + "I didn't get that.");
                }
                else
                {
                    NPCMessage("\n" + Name + " >> " + "See you later I guess.");
                }
            }
            else
            {
                NPCMessage("\n" + Name + " >> " + "I've told you everything I know.");
            }
            
        }

        public void NPCMessage(string message)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        public void moveRooms()
        {

        }

         
        //One NPC has a literal clone
        public virtual NPC Clone(Room room,string Name)
        {
            NPC clone = (NPC)this.MemberwiseClone();
            clone.Name = "" + Name;
            clone._IsImposter = false;
            clone._currentRoom = room;
            clone._currentRoom.AddNPC(clone);

            return clone;
        }

    };

    
    
}
/*
 * public class ItemSpawner
 * 
 * private IItem _prototype;
 * 
 * pubilc ItemSpawner(IItem prototype){
 * _prorotype = prototpye;
 * }
 * 
 * public IItem Spawn(){
 * return _prototype.Clone()
 * }
 * 
 */