using System.Collections;
using System.Collections.Generic;

namespace ImposterGameApp
{
    public class HelpCommand : Command
    {
        CommandWords words;

        public HelpCommand() : this(new CommandWords())
        {
        }

        public HelpCommand(CommandWords commands) : base()
        {
            words = commands;
            this.Name = "help";
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
                    player.OutputMessage("\nI cannot help you with " + this.SecondWord);
                }
                else
                {
                    player.OutputMessage("\nYou are located on a spaceship. To move, enter 'go' and a direction.  \n\nYour available commands are: \n" + words.Description());
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
