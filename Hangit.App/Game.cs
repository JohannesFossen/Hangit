using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public class Game
    {
        private char[] _wordtoguess;

        Game(string inWord)
        {
            _wordtoguess = inWord.ToCharArray();
            Console.WriteLine(_wordtoguess);
        }
    }
}
