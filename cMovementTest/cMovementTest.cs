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
            cAction movement = new cAction(3,3,0);
            cAction comparredMovement = new cAction(3, 3, 1);

            //Act
            bool result = movement.Equals(comparredMovement);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEqualsAssertFalse()
        {
            //Arrange
            cAction movement = new cAction(3, 2, 0);
            cAction comparredMovement = new cAction(3, 3, 1);

            //Act
            bool result = movement.Equals(comparredMovement);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
