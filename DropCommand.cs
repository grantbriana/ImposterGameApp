using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    class DropCommand : Command
    {
        public DropCommand() : base()
        {
            this.Name = "drop";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.DropRoomObject(this.SecondWord,player.CurrentRoom.roomObjects);
            }
            else
            {
                player.OutputMessage("\nDrop What?");
            }
            return false;
        }
    }
}
