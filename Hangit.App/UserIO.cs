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
        public static char ReadChar(int number)
        {
            char key;
            do
            {
                Console.Write($"Next one to try ({number}) > ");
                key = Console.ReadKey().KeyChar;
                if (key != 'Q') // Quit character.
                {
                    //Console.WriteLine("");
                    key = (key.ToString().ToUpper())[0];
                    if (key < 'A' || key > 'Z')
                    {
                        Console.WriteLine($" Illegal input '{key}'.");
                        key = ' ';
                    }
                }
            } while (key == ' ');
            return key;
        }
        public static void ShowText(string inText)
        {
            Console.WriteLine(inText);
        }
    }
}
