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
                    if (!((key >= 'A' && key <= 'Z') || key == 'Æ' || key == 'Ø' || key == 'Å'))
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
        internal static List<GuessWords> ReadGuessFile()
        {
            int number = 0;
            List<GuessWords> wordList;
            //string[] allLines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Data\GuessWords.txt");
            string[] allLines = File.ReadAllLines(@"C:\Users\jofos\source\repos\Hangit\Hangit.App\Data\GuessWords.txt");
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
