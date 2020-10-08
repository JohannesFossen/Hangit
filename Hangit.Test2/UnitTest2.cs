using Hangit.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangit.Test2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void keyexists_check_B_find_in_first()
        {
            // Arrange
            var chechArray1 = new char[] { 'A', 'B', 'C', 'D' };
            var checkChar = 'B';

            // Act
            var result = Evaluate.KeyExists(checkChar, chechArray1);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void keyexists_check_F_find_in_second()
        {
            // Arrange
            var chechArray1 = new char[] { 'A', 'B', 'C', 'D' };
            var chechArray2 = new char[] { '-', 'E', '-', 'F' };
            var checkChar = 'F';

            // Act
            var result = Evaluate.KeyExists(checkChar, chechArray2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void keyexists_check_I_find_in_third()
        {
            // Arrange
            var chechArray1 = new char[] { 'A', 'B', 'C', 'D' };
            var chechArray2 = new char[] { '-', 'E', '-', 'F' };
            var chechArray3 = new char[] { 'G', 'H', 'I', '-' };
            var checkChar = 'I';

            // Act
            var result = Evaluate.KeyExists(checkChar, chechArray1, chechArray2, chechArray3);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void keyexists_check_J_not_found_in_three()
        {
            // Arrange
            var chechArray1 = new char[] { 'A', 'B', 'C', 'D' };
            var chechArray2 = new char[] { '-', 'E', '-', 'F' };
            var chechArray3 = new char[] { 'G', 'H', 'I', '-' };
            var checkChar = 'J';

            // Act
            var result = Evaluate.KeyExists(checkChar, chechArray1, chechArray2, chechArray3);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
