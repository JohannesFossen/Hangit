using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess;
        private char[] _solution = new char[30];
        private char[] _guesses = "                              ".ToCharArray();
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
                UserIO.ShowCharString(_guesses);
                do
                {
                    key = UserIO.ReadChar(_triesleft);
                    if (Evaluate.GetCharPos(_guesses, key) >= 0)
                    {
                        UserIO.ShowText(" Tried already.");
                        key = ' ';
                    }
                } while (key == ' ');
                if (Evaluate.CheckSolution(key, _wordtoguess, _solution))
                {
                    UserIO.ShowText(" Hit!");
                    _triesleft--;
                }
                else
                {
                    UserIO.ShowText(" Miss.");
                    Evaluate.AddCharValue(_guesses, key);
                }
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
