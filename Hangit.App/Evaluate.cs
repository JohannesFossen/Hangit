using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public static class Evaluate
    {
        public static int GetCharPos(char[] inCharList, char find, int start = 0)
        {
            for (int i = start; i < inCharList.Length; i++)
                if (inCharList[i] == find)
                    return i;
            return -1;
        }
        public static bool CheckSolution(char tryChar,char[] inWordToCheck, char[] inScoreboard)
        {
            int pos = -1;
            bool hit = false;
            do
            {
                pos = GetCharPos(inWordToCheck, tryChar, pos+1);
                if (pos >= 0)
                {
                    // Correct character.
                    inScoreboard[pos] = tryChar;
                    hit = true;
                }
            } while (pos >= 0);
            return hit;
        }
        internal static void AddCharValue(char[] inCharList,char key)
        {
            inCharList[GetCharPos(inCharList,' ')] = key;
        }
    }
}
