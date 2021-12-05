using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImposterGameApp
{
    
    public class Door
    {
        private Room _room1;
        private Room _room2;
        //Controls whether door is locked or unlocked
        public bool _isLocked;
        

        public Door(Room room1, Room room2)
        {
            _room1 = room1;
            _room2 = room2;
            _isLocked = false;
        }

        public void setLock()
        {
            _isLocked = true;
        }

        public string Unlock()
        {
            //_isLocked == true
            if (_isLocked)
            {
                _isLocked = false;
                return "This door is now unlocked";
            }
            return "This room was already unlocked";
        }

        public Room OtherRoom(Room thisRoom)
        {
            
            if(thisRoom == _room1)
            {
                return _room2;
            }
            else
            {
                return _room1;
            }
            //return thisRoom == _room1 ? _room2 : _room1;
        }

        //Helper method
        public static Door connectRooms(Room fromRoom, Room toRoom, string fromTo, string toFrom)
        {
            Door door = new Door(fromRoom, toRoom);
            fromRoom.SetExit(toFrom, door);
            toRoom.SetExit(fromTo, door);
            return door;

        }
    }
}

