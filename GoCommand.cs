using System.Collections;
using System.Collections.Generic;

namespace ImposterGameApp
{
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.Name = "go";
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

                    player.WalkTo(this.SecondWord);

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
