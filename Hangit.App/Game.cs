using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess;
        private char[] _solution;
        private char[] _guesses;
        private int _triesleft = Program.maxTries;

        public Game(string inWord)
        {
            _wordtoguess = inWord.ToUpper().ToCharArray();
            int i = 0;
            foreach (char c in _wordtoguess)
                _solution[i++] = '-';
            Console.WriteLine(_wordtoguess);
        }
    }
}
