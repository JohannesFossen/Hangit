using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    public static class UserIO
    {
        public static void ShowCharString(char[] inString)
        {
            foreach (char c in inString)
                Console.Write($"{c} ");
            Console.WriteLine("");
        }
    }
}
