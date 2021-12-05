using System.Collections;
using System.Collections.Generic;
using System;

namespace ImposterGameApp
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;
        //GameClock gc;


        public Game()
        {
            //gc = new GameClock(5000);   //Game timer
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(GameWorld.Instance.Entrance);
        }

        private static Game _instance = null;


        public static Game Instance
        {
            get
            {
                // Lazy Initializer
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }





        //Game Sequence Design: Game loop
        /*
        *  Main play routine.  Loops until end of play.
        */
        public void Play()
        {
            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine("I don't understand...");
                }
                else
                {
                    finished = command.Execute(player);
                    playing = finished;
                }
               
            }
        }

        public void Start()
        {

            playing = true;
            player.OutputMessage(Welcome());
        }


        public void End()
        {
            //if npcPlayer.alive = false OR if user.alive = false, OutputMessage: You lost! 
            //If imposter.alive = false, OutputMessage: You won! 
            playing = false;
            player.OutputMessage(Goodbye());
        }

        public string Welcome()
        {
            String intro = "\n\nYou are a crewmember on a spaceship returning to Earth.\n\n As the mission goes on, strange events begin to occur..." +
                "\n\n Find Hints & clues among your spaceship in order to find the imposter. (kill the imposter)"
                + "\n\nType 'help' if you need help.\n" + player.CurrentRoom.Description(); 
           
            return intro;
        }

        public string ASCII()
        {
            string title = "";         
            return title;
        }

        
        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
                                                                                                                                              


