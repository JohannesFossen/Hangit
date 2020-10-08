using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    internal class GuessWords
    {
        internal int Number;
        internal string Word;
        internal string Hint;
        public GuessWords(int number, string word, string hint)
        {
            Number = number;
            Word = word;
            Hint = hint;
        }
    }
    public class Game
    {
        private char[] _wordtoguess; // OO: Try hit Alt-Enter (this will add "readonly" keyword)
        private char[] _scoreboard = new char[30];                                   // OO: Try another datatype so you're not limited to 30 chars
        private char[] _missed = "                              ".ToCharArray();     // OO: Try another datatype so you're not limited to 30 chars
        private int _triesleft = Program.maxTries;
        //private GuessWords _guessobj;
        private static List<GuessWords> _words;

        public Game()
        {
            //List<GuessWords> _words = new List<GuessWords>();
            //List<GuessWords> _words;
             if (_words == null)
            {
                // Read file only once.
                //_words = new List<GuessWords>();
                _words = UserIO.ReadGuessFile();
            }
        }
        internal void GameReset()
        {
            _scoreboard = "                              ".ToCharArray();
            _missed     = "                              ".ToCharArray();
            Random rnd = new Random();
            int tmp = _words.Count;
            int rndint = rnd.Next(0, (_words.Count - 1));
            GuessWords guessObj = _words.Find(w => w.Number == rndint); // Random error: Outside array bounds.
            //GuessWords guessObj = _words.Find(w => w.Number == rnd.Next(0, (_words.Count - 1))); // Random error: Outside array bounds.
            _wordtoguess = guessObj.Word.ToUpper().ToCharArray();
            int i = 0;
            foreach (char c in _wordtoguess)
                _scoreboard[i++] = '-';
            UserIO.ShowText($"The hint is: {guessObj.Hint}.");
            //Console.WriteLine(_wordtoguess); // Just for test...

        }
        public void Play()
        {
            char key;
            bool done = false;
            GameReset();
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
                        // OO: Hint, create one more method that describes what you're checking here (that method may call Evaluate.GetCharPos)
                        //if (Evaluate.GetCharPos(_missed, key) >= 0 || Evaluate.GetCharPos(_scoreboard, key) >= 0)
                        if(Evaluate.KeyExists(key,_missed,_scoreboard))
                        {
                            UserIO.ShowText(" Tried already.",ConsoleColor.Yellow);
                            key = ' ';
                        }
                    }
                } while (key == ' ');
                // Check if key is a hit.
                if (key != 'Q')
                {
                    //if (Evaluate.CheckSolution(key, _wordtoguess, _scoreboard)) // OO: quite good name, but you might give it an even better name
                    if (Evaluate.HitOrMiss(key, _wordtoguess, _scoreboard))
                    {
                        UserIO.ShowText(" Hit!", ConsoleColor.Green);
                    }
                    else
                    {
                        UserIO.ShowText(" Miss.",ConsoleColor.Red);
                        Evaluate.AddCharValue(key, _missed);
                        _triesleft--;
                    }
                }
                // Winner or bust? Or Quit...
                //if (!Evaluate.GetCharPos(_scoreboard,'-') == -1)  // OO: here you can have a method like "Evaluate.PlayerHasWon(_scoreboard)" or "Evaluate.NoOccurrance('-', _scoreboard)" or "!Evaluate.Contains('-', _scoreboard)"
                if (!Evaluate.KeyExists('-',_scoreboard))
                {
                    UserIO.ShowCharString(_scoreboard);
                    UserIO.ShowText("Winner!", ConsoleColor.Green);
                    done = true;
                }else if (_triesleft == 0)
                {
                    UserIO.ShowText($"Sorry, you spent all {Program.maxTries} tries. The solution was:", ConsoleColor.Red);
                    UserIO.ShowCharString(_wordtoguess);
                    done = true;
                } else if (key == 'Q')
                {
                    UserIO.ShowText("");
                    UserIO.ShowText($"Game aborted. The solution was:", ConsoleColor.Red);
                    UserIO.ShowCharString(_wordtoguess);
                    done = true;

                }
            } while (!done);
        }
    }
}
