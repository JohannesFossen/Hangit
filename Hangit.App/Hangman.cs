// Inte "Console.Write" eller "Console.Read" eller "User.IO"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangit.App
{

    public enum GuessResult
    {
        CorrectGuess, IncorrectGuess, InvalidGuess, AlreadyGuessed, QuitPlay
    }

    public class Hangman
    {
        // "Minnet"

        //private List<char> _guesses = new List<char>(); // (exempelvis)
        private char[] _secretword;
        private char[] _scoreboard = "                    ".ToCharArray();
        private char[] _misses = "                    ".ToCharArray();

        public Hangman(string secretWord)
        {
            //SecretWord = secretWord;
            _secretword = secretWord.ToCharArray();
            int i = 0;
            foreach (char c in _secretword)
                _scoreboard[i++] = '-';
        }

        //public string SecretWord { get; }

        public GuessResult Guess(char guess)
        {
            //_guesses.Add(guess);
            //throw new NotImplementedException();
            if (guess == 'Q')
                return GuessResult.QuitPlay;

            if (!Evaluate.LegalKey(guess))
                return GuessResult.InvalidGuess;

            if (Evaluate.KeyExists(guess, _misses, _scoreboard))
                return GuessResult.AlreadyGuessed;

            if (Evaluate.HitOrMiss(guess, _secretword, _scoreboard))
                return GuessResult.CorrectGuess;

            Evaluate.AddCharValue(guess, _misses);
            return GuessResult.IncorrectGuess;
        }
        public void Play()
        {
            char guess;
            int numberOfTries = 10;
            bool done = false;
            do
            {
                UserIO.ShowText("Starting the guess!");
                UserIO.ShowCharString(_scoreboard);
                UserIO.ShowCharString(_misses);
                guess = UserIO.ReadChar(numberOfTries);
                switch (Guess(guess))
                {
                    case GuessResult.InvalidGuess:
                        Console.WriteLine($" Illegal input '{guess}'.");
                        break;
                    case GuessResult.AlreadyGuessed:
                        UserIO.ShowText(" Tried already.", ConsoleColor.Yellow);
                        break;
                    case GuessResult.IncorrectGuess:
                        UserIO.ShowText(" Miss.", ConsoleColor.Red);
                        numberOfTries--;
                        break;
                    case GuessResult.CorrectGuess:
                        UserIO.ShowText(" Hit.", ConsoleColor.Green);
                        break;
                    case GuessResult.QuitPlay:
                        break;
                    default:
                        break;
                }
                if (!Evaluate.KeyExists('-', _scoreboard))
                {
                    UserIO.ShowCharString(_scoreboard);
                    UserIO.ShowText("Winner!", ConsoleColor.Green);
                    done = true;
                }
                else if (numberOfTries == 0)
                {
                    UserIO.ShowText($"Sorry, you spent all {Program.maxTries} tries. The solution was:", ConsoleColor.Red);
                    UserIO.ShowCharString(_secretword);
                    done = true;
                }
                else if (guess == 'Q')
                {
                    UserIO.ShowText("");
                    UserIO.ShowText($"Game aborted. The solution was:", ConsoleColor.Red);
                    UserIO.ShowCharString(_secretword);
                    done = true;

                }
            } while (!done);
        }
    }
}
