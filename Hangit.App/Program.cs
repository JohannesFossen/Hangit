using System;

namespace Hangit.App
{
    class Program
    {
        public static int maxTries = 10;
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}
