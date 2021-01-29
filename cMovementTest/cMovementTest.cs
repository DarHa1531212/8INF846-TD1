using System;
using AI_TD1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
namespace cMovementTest
{
    [TestClass]
    public class cMovementTest
    {
        [TestMethod]
        public void TestEqualsAssertTrue()
        {
            //Arrange
            cMovement movement = new cMovement(3,3,0);
            cMovement comparredMovement = new cMovement(3, 3, 1);

            //Act
            bool result = movement.Equals(comparredMovement);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEqualsAssertFalse()
        {
            //Arrange
            cMovement movement = new cMovement(3, 2, 0);
            cMovement comparredMovement = new cMovement(3, 3, 1);

            //Act
            bool result = movement.Equals(comparredMovement);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
