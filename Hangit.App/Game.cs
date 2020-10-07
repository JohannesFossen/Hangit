using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess;
        private char[] _scoreboard = new char[30];
        private char[] _missed = "                              ".ToCharArray();
        private int _triesleft = Program.maxTries;

        public Game(string inWord)
        {
            _wordtoguess = inWord.ToUpper().ToCharArray();
            int i = 0;
            foreach (char c in _wordtoguess)
                _scoreboard[i++] = '-';
            Console.WriteLine(_wordtoguess); // Just for test...
        }
        public void Play()
        {
            char key;
            bool done = false;
            UserIO.ShowText("Starting the guess!");
            do
            {
                // Show current score.
                UserIO.ShowCharString(_scoreboard);
                UserIO.ShowCharString(_missed);
                // Read one key and check if tried already.
                do
                {
                    key = UserIO.ReadChar(_triesleft);
                    if (key != 'Q') // Quit character.
                    {
                        if (Evaluate.GetCharPos(_missed, key) >= 0)
                        {
                            UserIO.ShowText(" Tried already.");
                            key = ' ';
                        }
                    }
                } while (key == ' ');
                // Check if key is a hit.
                if (key != 'Q')
                {
                    if (Evaluate.CheckSolution(key, _wordtoguess, _scoreboard))
                    {
                        UserIO.ShowText(" Hit!");
                        _triesleft--;
                    }
                    else
                    {
                        UserIO.ShowText(" Miss.");
                        Evaluate.AddCharValue(_missed, key);
                    }
                }
                // Winner or bust? Or Quit...
                if (Evaluate.GetCharPos(_scoreboard,'-') == -1)
                {
                    UserIO.ShowCharString(_scoreboard);
                    UserIO.ShowText("Winner!");
                    done = true;
                }else if (_triesleft == 0)
                {
                    UserIO.ShowText($"Sorry, you spent all {Program.maxTries} tries. The solution was:");
                    UserIO.ShowCharString(_wordtoguess);
                    done = true;
                } else if (key == 'Q')
                {
                    UserIO.ShowText("");
                    UserIO.ShowText($"Game aborted. The solution was:");
                    UserIO.ShowCharString(_wordtoguess);
                    done = true;

                }
            } while (!done);
        }
    }
}
