using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public static class Evaluate
    {
        public static bool LegalKey(char key)
        {
            return ((key >= 'A' && key <= 'Z') || key == 'Æ' || key == 'Ø' || key == 'Å');
        }
        public static int GetCharPos(char[] inCharList, char find, int start = 0)
        {
            // OO: when you do a method it's good to be suspicious on the parameters. And throw exceptions if they are incorrect (e.g "start" is a negative number or too high)

            for (int i = start; i < inCharList.Length; i++)
                if (inCharList[i] == find)
                    return i;
            return -1;
        }
        public static bool KeyExists(char key, char[] inCheckArray1, char[] inCheckArray2 = null, char[] inCheckArray3 = null)
        {
            bool found;
            found = (Evaluate.GetCharPos(inCheckArray1, key) >= 0);
            if (!found && inCheckArray2 != null)
                found = (Evaluate.GetCharPos(inCheckArray2, key) >= 0);
            if (!found && inCheckArray3 != null)
                found = (Evaluate.GetCharPos(inCheckArray3, key) >= 0);
            return found;
        }
        public static bool HitOrMiss(char tryChar,char[] inWordToCheck, char[] inScoreboard)
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
        internal static void AddCharValue(char key, char[] inCharList)
        {
            inCharList[GetCharPos(inCharList,' ')] = key;
        }
    }
}
