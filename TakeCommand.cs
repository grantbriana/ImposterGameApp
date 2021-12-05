using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base()
        {
            this.Name = "take";
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
                    //player.CurrentRoom.TakeRoomObject(this.SecondWord, player);
                    player.TakeRoomObject(this.SecondWord);
                }
                else if (this.HasThirdWord())
                {
                    player.TakeRoomObject(this.SecondWord + " " + this.ThirdWord);
                }
                else
                {
                    player.ErrorMessage("\nTake What?");
                }
            }

            else
            {
                player.OutputMessage("Game Over. Type 'quit' to exit game");
            }

            return false;
        }
    }
}
