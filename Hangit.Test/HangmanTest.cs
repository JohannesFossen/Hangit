using Hangit.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangit.Test
{
    [TestClass]
    public class HangmanTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var h = new Hangman("UTEPILS");

            GuessResult result = h.Guess('E');

            Assert.AreEqual(GuessResult.CorrectGuess, result);
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            var h = new Hangman("UTEPILS");

            GuessResult result1 = h.Guess('E');
            GuessResult result2 = h.Guess('E');

            Assert.AreEqual(GuessResult.AlreadyGuessed, result2);
        }

        [TestMethod]
        public void MyTestMethod3()
        {
            var h = new Hangman("UTEPILS");

            GuessResult result = h.Guess('#');

            Assert.AreEqual(GuessResult.InvalidGuess, result);
        }
    }
}
