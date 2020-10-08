using System;

namespace Hangit.App
{
    class Program
    {
        public static int maxTries = 10;
        static void Main(string[] args)
        {
            char key;
            Game game = new Game();
            Hangman hangman = new Hangman("UTEPILS");
            hangman.Play();
            return;
            do
            {
                game.Play();
                
                key = UserIO.ReadOneChar("\nPlay more (y)? ");
            } while (key != 'n' && key != 'N');
        }
    }
}
