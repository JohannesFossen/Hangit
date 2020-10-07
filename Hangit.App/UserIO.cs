using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    class UserIO
    {
        public void ShowCharString(char[] inString)
        {
            foreach (char c in inString)
                Console.Write($"{c} ");
            Console.WriteLine("");
        }
    }
}
