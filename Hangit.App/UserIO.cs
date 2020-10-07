using System;
using System.Collections.Generic;
using System.Text;

namespace Hangit.App
{
    class UserIO
    {
        public ShowSolution(char[] inSolution)
        {
            foreach (char c in inSolution)
                Console.Write($"{c} ");
            Console.WriteLine("");
        }
    }
}
