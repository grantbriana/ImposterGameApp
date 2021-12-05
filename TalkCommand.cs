using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    class TalkCommand: Command
    {
            
        public TalkCommand() : base()
        {
            this.Name = "talk";
        }

        override
        public bool Execute(Player player)
        {
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");


            //Player can no longer navigate rooms if State is won or lost
            if (player.GetCurrentState != lost && player.GetCurrentState != won)
            {
                if (this.HasSecondWord())
                {
                    player.TalkTo(SecondWord);
                }

                else
                {
                    player.OutputMessage("\nGo Where?");
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


