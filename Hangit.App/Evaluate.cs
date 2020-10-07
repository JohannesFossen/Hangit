using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public static class Evaluate
    {
        internal static int GetCharPos(char[] inCharList, char find, int start = 0)
        {
            for (int i = start; i < inCharList.Length; i++)
                if (inCharList[i] == find)
                    return i;
            return -1;
        }
    }
}
