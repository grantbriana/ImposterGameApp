﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace ImposterGameApp
{
    public class Parser
    {
        private CommandWords commands;

        public Parser() : this(new CommandWords())
        {

        }

        public Parser(CommandWords newCommands)
        {
            commands = newCommands;
        }

        public Command ParseCommand(string commandString)
        {
            Command command = null;
            string[] words = commandString.Split(' ');
            if (words.Length > 0)
            {
                command = commands.Get(words[0]);
                if (command != null)
                {
                    if (words.Length == 2)
                    {
                        command.SecondWord = words[1];
                    }
                    else if (words.Length == 3)
                    {
                        command.SecondWord = words[1];
                        command.ThirdWord = words[2];
                    }
                    else if (words.Length == 4)
                    {
                        command.SecondWord = words[1];
                        command.ThirdWord = words[2];
                        command.FourthWord = words[3];
                    }
                   
                    //redundant?
                    else
                    {
                        command.SecondWord = null;
                    }
                }
                else
                {
                    Console.WriteLine(">>>Did not find the command " + words[0]);
                }
            }
            else
            {
                Console.WriteLine("No words parsed!");
            }
            return command;
        }

        public string Description()
        {
            return commands.Description();
        }
    }
}
