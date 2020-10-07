using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess; // OO: Try hit Alt-Enter (this will add "readonly" keyword)
        private char[] _scoreboard = new char[30];                                   // OO: Try another datatype so you're not limited to 30 chars
        private char[] _missed = "                              ".ToCharArray();     // OO: Try another datatype so you're not limited to 30 chars
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
                        if (Evaluate.GetCharPos(_missed, key) >= 0)   // OO: Hint, create one more method that describes what you're checking here (that method may call Evaluate.GetCharPos)
                        {
                            UserIO.ShowText(" Tried already.");
                            key = ' ';
                        }
                    }
                } while (key == ' ');
                // Check if key is a hit.
                if (key != 'Q')
                {
                    if (Evaluate.CheckSolution(key, _wordtoguess, _scoreboard)) // OO: quite good name, but you might give it an even better name
                    {
                        UserIO.ShowText(" Hit!");
                    }
                    else
                    {
                        UserIO.ShowText(" Miss.");
                        Evaluate.AddCharValue(_missed, key);
                        _triesleft--;
                    }
                }
                // Winner or bust? Or Quit...
                if (Evaluate.GetCharPos(_scoreboard,'-') == -1)  // OO: here you can have a method like "Evaluate.PlayerHasWon(_scoreboard)" or "Evaluate.NoOccurrance('-', _scoreboard)" or "!Evaluate.Contains('-', _scoreboard)"
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
