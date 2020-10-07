using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess;
        private char[] _solution = new char[30];//"".ToCharArray();
        private char[] _guesses = new char[30];
        private int _triesleft = Program.maxTries;

        public Game(string inWord)
        {
            _wordtoguess = inWord.ToUpper().ToCharArray();
            int i = 0;
            foreach (char c in _wordtoguess)
                _solution[i++] = '-';
            Console.WriteLine(_wordtoguess);
        }
        public void Play()
        {
            char key;
            bool done = false;
            UserIO.ShowText("Starting the guess!");
            do
            {
                UserIO.ShowCharString(_solution);
                //UserIO.ShowCharString($"Tries left");
                do
                {
                    key = UserIO.ReadChar();
                } while (false);
                if (Evaluate.CheckSolution(key, _wordtoguess, _solution))
                {
                    UserIO.ShowText(" Hit!");
                    _triesleft--;
                }
                else
                    UserIO.ShowText(" Miss.");
                if (Evaluate.GetCharPos(_solution,'-') == -1)
                {
                    UserIO.ShowCharString(_solution);
                    UserIO.ShowText("Winner!");
                    done = true;
                }
            } while (!done);
        }
    }
}
