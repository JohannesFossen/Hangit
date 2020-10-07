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

        #region constructor
        public Game(string inWord)
        {
            _wordtoguess = inWord.ToUpper().ToCharArray();
            int i = 0;
            foreach (char c in _wordtoguess)
                _solution[i++] = '-';
            Console.WriteLine(_wordtoguess);
        }
        #endregion

        internal int GetCharPos(char[] inCharList,char find,int start=0)
        {
            for (int i=start;i<inCharList.Length; i++)
                if (inCharList[i] == find)
                    return i;
            return -1;
        }
    }
}
