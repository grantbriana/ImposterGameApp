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
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");

            if (player.GetCurrentState != lost && player.GetCurrentState != won)
            {
                if (this.HasSecondWord() && !this.HasThirdWord())
                {
                    player.DropRoomObject(this.SecondWord, player.CurrentRoom.roomObjects);
                }
                else if (this.HasThirdWord())
                {
                    player.DropRoomObject(this.SecondWord + " " + this.ThirdWord, player.CurrentRoom.roomObjects);
                }
                else
                {
                    player.OutputMessage("\nDrop What?");
                }
            }
            return false;
        }
    }
}
