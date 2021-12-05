using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    //Back Command: Returns player to previous room 
    public class BackCommand: Command
    {

        public BackCommand() : base()
        {
            this.Name = "back";
        }

        override
        public bool Execute(Player player)
        {
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");

            if (player.GetCurrentState != lost && player.GetCurrentState != won)
            {
                player.WalkToPreviousRoom();
            }
            else
            {
                player.OutputMessage("Game Over. Type 'quit' to exit game");
            }
            return false;

        }
    }
}
