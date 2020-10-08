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
        private char[] _misses     = "                    ".ToCharArray();

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
    }
}
