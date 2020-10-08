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

        // todo: skapa två till tester för "GetCharPos"
    }

    // todo: skapa tre tester för "CheckSolution"

    // todo: tid över? testa fler metoder

}
