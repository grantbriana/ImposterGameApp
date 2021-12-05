using System;

namespace ImposterGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There's an imposter among you!");
            Game game = new Game();
            game.Start();
            game.Play();
            game.End();
        }
    }
}

