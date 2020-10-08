using Hangit.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //public void should_return_index_2_when_searching_for_C()
        public void getcharpos_search_C_from_start_returns_2()
        {
            // Arrange
            var array = new char[] { 'A', 'B', 'C', 'D' };
            var charToFind = 'C';
            var startIndex = 0;

            // Act
            var result = Evaluate.GetCharPos(array, charToFind, startIndex);

            // Assert
            Assert.AreEqual(2, result);

        }
        [TestMethod]
        // todo: skapa två till tester för "GetCharPos"
        public void getcharpos_search_A_from_mid_returns_minus1()
        {
            // Arrange
            var array = new char[] { 'A', 'B', 'C', 'D' };
            var charToFind = 'A';
            var startIndex = 1;

            // Act
            var result = Evaluate.GetCharPos(array, charToFind, startIndex);

            // Assert
            Assert.AreEqual(-1, result);

        }
        [TestMethod]
        public void getcharpos_search_D_from_mid_returns_3()
        {
            // Arrange
            var array = new char[] { 'A', 'B', 'C', 'D' };
            var charToFind = 'D';
            var startIndex = 1;

            // Act
            var result = Evaluate.GetCharPos(array, charToFind, startIndex);

            // Assert
            Assert.AreEqual(3, result);
        }

        // todo: skapa tre tester för "CheckSolution" -> "HitOrMiss"
        [TestMethod]
        public void checksolution_check_A_returns_true()
        {
            // Arrange
            var word = new char[] { 'A', 'B', 'C', 'D' };
            var score = new char[] { '-', 'B', '-', '-' };
            var checkChar = 'A';
            
            // Act
            var result = Evaluate.HitOrMiss(checkChar, word, score);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual('A', score[0]);
        }
        [TestMethod]
        public void checksolution_check_E_returns_false()
        {
            // Arrange
            var word = new char[] { 'A', 'B', 'C', 'D' };
            var score = new char[] { '-', 'B', '-', '-' };
            var checkChar = 'E';

            // Act
            var result = Evaluate.HitOrMiss(checkChar, word, score);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual('-', score[0]);
            Assert.AreEqual('B', score[1]);
            Assert.AreEqual('-', score[2]);
            Assert.AreEqual('-', score[3]);
        }
    }

    // todo: tid över? testa fler metoder

}
