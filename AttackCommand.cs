using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
{
    public class AttackCommand : Command
    {
        public AttackCommand() : base()
        {
            this.Name = "attack";
        }

        //Syntax: Attack (npc) weapon
        override
        public bool Execute(Player player)
        {
            /* if (this.HasFourthWord() && !this.HasFifthWord())
             {
                 //player.WalkTo(this.SecondWord);
             }*/
            State lost = player.GetState("Lost");
            State won = player.GetState("Won");

            if (player.GetCurrentState != won && player.GetCurrentState != lost)
            {
                //attack red knife
                if (this.HasThirdWord())
                {
                    player.KillImposter(SecondWord, ThirdWord);

                    if (player.GetCurrentState != won && player.GetCurrentState != lost)
                    {
                        player.ErrorMessage("Keep Trying!");
                    }

                    //if attack successful
                    else if (player.GetCurrentState == won)
                    {
                        player.WinnerMessage("Right, they were the imposter");

                    }
                    else if (player.GetCurrentState == lost)
                    {
                        player.LoserMessage("They weren't the imposter!!!");
                    }
                }

                //attack red laser gun
                else if (this.HasFourthWord())
                {
                    player.KillImposter(SecondWord, ThirdWord + " " + FourthWord);

                    /*if (player.GetCurrentState != won && player.GetCurrentState != lost)
                      {
                          player.ErrorMessage("Keep Trying!");
                      }*/

                    //if attack successful
                    if (player.GetCurrentState == won)
                    {
                        player.WinnerMessage("Right, they were the imposter");

                    }
                    else if (player.GetCurrentState == lost)
                    {
                        player.LoserMessage("They weren't the imposter!!!");
                    }
                }

                else
                {
                    player.ErrorMessage("\nAttack Who with What?");
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

/*
 * //player.attack(who,weapon) *(this.HasSecondWord(), this.HasThirdWord() + " " + this.HasFourthWord())

                    //if attack successful
                    player.KillImposter(SecondWord, ThirdWord);
                    
                    //player.WinnerMessage("You killed the imposter!\n\nYou Won!\nGameOver.\nType 'quit' to exit");
                    //player.ChangeState(won);
                    


                    //if attack failed
                    else
                    {
                        player.LoserMessage("You lost!\n\nGameOver.\nType 'quit' to exit");
                        player.ChangeState(lost);
                    }
                }
                

                /*
                //atack orange laser gun
                else if (this.HasFourthWord())
                {
                    if (player.KillImposter(SecondWord, ThirdWord + " " + FourthWord))
                    {
                        player.WinnerMessage("You killed the imposter!\n\nYou Won!\nGameOver.\nType 'quit' to exit");
                        player.ChangeState(won);
                    }
                    else
                    {
                        player.LoserMessage("You lost!\n\nGameOver.\nType 'quit' to exit");
                        player.ChangeState(lost);
                    }
                
                else
{
    player.ErrorMessage("\nAttack Who with What?");
}
            }
            return false;
        }
    }
}}*/

 