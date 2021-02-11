using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI_TD1;

namespace cTests
{
    [TestClass]
    public class cActionTest
    {
        [TestMethod]
        public void T_Equals_Self_True()
        {
            //Arrange
            cAction action1 = new cAction(Actions.Down, 3);

            //Act
            bool isEqual = action1.Equals(action1);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void T_Equals_Multiple_True()
        {
            //Arrange
            cAction action1 = new cAction(Actions.Down, 3);
            cAction action2 = new cAction(Actions.Down, 3);

            //Act
            bool isEqual = action1.Equals(action2);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void T_Equals_Multiple_DifferentAction_False()
        {
            //Arrange
            cAction action1 = new cAction(Actions.Down, 3);
            cAction action2 = new cAction(Actions.Up, 3);

            //Act
            bool isEqual = action1.Equals(action2);

            //Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void T_Equals_Multiple_DifferentCost_False()
        {
            //Arrange
            cAction action1 = new cAction(Actions.Up, 3);
            cAction action2 = new cAction(Actions.Up, 4);

            //Act
            bool isEqual = action1.Equals(action2);

            //Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void T_Equals_Multiple_NothingEqual_False()
        {
            //Arrange
            cAction action1 = new cAction(Actions.Vacuum, 3);
            cAction action2 = new cAction(Actions.Down, 4);

            //Act
            bool isEqual = action1.Equals(action2);

            //Assert
            Assert.IsFalse(isEqual);
        }
    }
}
