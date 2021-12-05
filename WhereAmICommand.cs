using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    class WhereAmICommand : Command
    {
        public WhereAmICommand() : base()
        {
            this.Name = "where";
        }

        override
        public bool Execute(Player player)
        {
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");

            if (player.GetCurrentState != lost && player.GetCurrentState != won)
            {
                if (this.SecondWord.Equals("am") && this.ThirdWord.Equals("i"))
                {
                    player.OutputMessage(player.CurrentRoom.Tag);
                }
                else
                {
                    player.OutputMessage("I don't understand this commmand.");
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
