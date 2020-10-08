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
        CorrectGuess, IncorrectGuess, InvalidGuess, AlreadyGuessed
    }

    public class Hangman
    {
        // "Minnet"

        private List<char> _guesses = new List<char>(); // (exempelvis)

        public Hangman(string secretWord)
        {
            SecretWord = secretWord;
        }

        public string SecretWord { get; }

        public GuessResult Guess(char guess)
        {
            _guesses.Add(guess);
            throw new NotImplementedException();
        }
    }
}
