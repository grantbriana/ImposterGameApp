using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    public class InspectCommand : Command
    {

        public InspectCommand() : base()
        {
            this.Name = "inspect";
        }

        override
        public bool Execute(Player player)
        {
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");

            if (player.GetCurrentState != lost && player.GetCurrentState != won)
            {
                if (this.HasSecondWord())
                {
                    player.Inspect(this.SecondWord);
                }
                else
                {
                    player.OutputMessage("\nInspect What?");
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