using Hangit.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void should_return_index_2_when_searching_for_C()
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

        // todo: skapa tv� till tester f�r "GetCharPos"
    }

    // todo: skapa tre tester f�r "CheckSolution"

    // todo: tid �ver? testa fler metoder

}
