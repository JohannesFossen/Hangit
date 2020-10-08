using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
        public static char ReadChar(int number)   // OO: Nice method, just think about the name of the method
        {
            char key;
            do
            {
                Console.Write($"Next one to try ({number}) > ");
                key = Console.ReadKey().KeyChar;
                if (key != 'Q') // Quit character.   // OO: Detail, if you create a variable named QuitCharacter, then you don't need the comment
                {
                    //Console.WriteLine("");
                    key = (key.ToString().ToUpper())[0];
                    if (!((key >= 'A' && key <= 'Z') || key == 'Æ' || key == 'Ø' || key == 'Å'))
                    {
                        Console.WriteLine($" Illegal input '{key}'.");
                        key = ' ';
                    }
                }
            } while (key == ' ');
            return key;
        }
        public static char ReadOneChar(string inText)
        {
            char key;
            Console.Write(inText);
            key = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            return key;
        }
        public static void ShowText(string inText, ConsoleColor color = ConsoleColor.White)
        {
            if (color == ConsoleColor.White)
                Console.WriteLine(inText);
            else
            {
                Console.ForegroundColor = color;
                Console.WriteLine(inText);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        internal static List<GuessWords> ReadGuessFile()
        {
            int number = 0;
            List<GuessWords> wordList;
            //string[] allLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Data\GuessWords.txt");
            string[] allLines = File.ReadAllLines(@"Data\GuessWords.txt");
            wordList = allLines.Select(line => new GuessWords(
                number++,
                line.Split(',', StringSplitOptions.RemoveEmptyEntries)[0],
                line.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]
            )).ToList();
            ShowText($"Loaded {wordList.Count} guesswords.");
            return wordList;
        }
    }
}
