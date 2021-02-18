using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI_TD1;

namespace cTests
{
    [TestClass]
    public class cSmartAgentTest
    {
        // Intérêt de ces attributs ?
        public cSmartAgentTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //[TestMethod]
        //public void T_FindValidMoves_AllMovements_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_LeftWall_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'B', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_RightWall_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', 'B', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopWall_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'B', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'B', 'D', 'B', '*', 'B' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 2 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 2));
        //    expectedValidActions.Add(new cAction(Actions.Right, 2));
        //    expectedValidActions.Add(new cAction(Actions.Left, 2));
        //    expectedValidActions.Add(new cAction(Actions.Down, 2));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(1, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopLeftCorner_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'B', '*', '*', 'B', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'B', 'D', 'B', '*', 'B' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopRightCorner_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'B', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomLeftCorner_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', 'B' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomRight_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', 'B' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomWall_OnBoth()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'B', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', 'B' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 5 - 9 + 12));
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 5));
        //    expectedValidActions.Add(new cAction(Actions.Right, 5));
        //    expectedValidActions.Add(new cAction(Actions.Left, 5));
        //    expectedValidActions.Add(new cAction(Actions.Up, 5));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(4, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_AllMovements_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 4 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 4));
        //    expectedValidActions.Add(new cAction(Actions.Left, 4));
        //    expectedValidActions.Add(new cAction(Actions.Down, 4));
        //    expectedValidActions.Add(new cAction(Actions.Up, 4));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(3, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_LeftWall_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_RightWall_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', 'D', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopWall_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'D', 'D', 'D', '*', 'D' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 2 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 2));
        //    expectedValidActions.Add(new cAction(Actions.Left, 2));
        //    expectedValidActions.Add(new cAction(Actions.Down, 2));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(1, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopLeftCorner_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'D', 'D', 'D', '*', 'D' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopRightCorner_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'D', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomLeftCorner_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', 'D' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomRight_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', 'D' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 1 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomWall_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'D', 'D', 'D', '*', '*' },
        //        {'*', '*', 'J', '*', 'D' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Vacuum, 5 - 9));
        //    expectedValidActions.Add(new cAction(Actions.Right, 5));
        //    expectedValidActions.Add(new cAction(Actions.Left, 5));
        //    expectedValidActions.Add(new cAction(Actions.Up, 5));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(4, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_AllMovements_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 2));
        //    expectedValidActions.Add(new cAction(Actions.Right, 2));
        //    expectedValidActions.Add(new cAction(Actions.Left, 2));
        //    expectedValidActions.Add(new cAction(Actions.Down, 2));
        //    expectedValidActions.Add(new cAction(Actions.Up, 2));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(1, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_LeftWall_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'J', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_RightWall_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', 'J', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopWall_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', 'J', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'J', 'D', 'J', '*', 'J' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 2));
        //    expectedValidActions.Add(new cAction(Actions.Right, 2));
        //    expectedValidActions.Add(new cAction(Actions.Left, 2));
        //    expectedValidActions.Add(new cAction(Actions.Down, 2));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(1, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopLeftCorner_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'J', '*', '*', 'J', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'J', 'D', 'J', '*', 'J' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopRightCorner_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'J', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomLeftCorner_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', 'J' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomRight_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', 'J' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomWall_OnJewel()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'J', 'D', 'J', '*', '*' },
        //        {'*', '*', 'J', '*', 'J' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.PickUp, 5));
        //    expectedValidActions.Add(new cAction(Actions.Right, 5));
        //    expectedValidActions.Add(new cAction(Actions.Left, 5));
        //    expectedValidActions.Add(new cAction(Actions.Up, 5));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(4, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_AllMovements_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', 'B', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(1, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_LeftWall_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_RightWall_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopWall_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 2));
        //    expectedValidActions.Add(new cAction(Actions.Left, 2));
        //    expectedValidActions.Add(new cAction(Actions.Down, 2));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(1, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopLeftCorner_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_TopRightCorner_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Down, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomLeftCorner_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomRight_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(4, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Left, 1));
        //    expectedValidActions.Add(new cAction(Actions.Up, 1));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(0, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_FindValidMoves_BottomWall_OnNothing()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 4, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedValidActions = new List<cAction>();
        //    expectedValidActions.Add(new cAction(Actions.Right, 5));
        //    expectedValidActions.Add(new cAction(Actions.Left, 5));
        //    expectedValidActions.Add(new cAction(Actions.Up, 5));

        //    //Act
        //    List<cAction> validActions = agent.FindValidActions(4, environment);

        //    //Assert
        //    CollectionAssert.AreEqual(validActions, expectedValidActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_OnDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'D', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Vacuum, (1 - 9 - 25)));
        //    expectedActions.Add(new cAction(Actions.None, 1 - 9 - 25));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    cAction initialSetup = new cAction(Actions.None, 0);
        //    actionsList.Add(initialSetup);
        //    List<cEnvironment> forbiddenList = new List<cEnvironment>();
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, forbiddenList);

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_LineOfDust()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', '*', '*', '*' },
        //        {'D', '*', '*', '*', '*' },
        //        {'D', '*', '*', '*', '*' },
        //        {'D', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Right, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -7));
        //    expectedActions.Add(new cAction(Actions.Right, -6));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -14));
        //    expectedActions.Add(new cAction(Actions.Right, -13));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -21));
        //    expectedActions.Add(new cAction(Actions.Right, -20));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -19 - 9 - 25));
        //    expectedActions.Add(new cAction(Actions.None, -19 - 9 - 25));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_Dusts()
        //{
        //    //Note, if max depth in recursive ds function is shorter than the list, this unit test will fail

        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', 'D', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', 'D' }
        //    };
        //    cEnvironment environment = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Right, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -7));
        //    expectedActions.Add(new cAction(Actions.Down, -6));
        //    expectedActions.Add(new cAction(Actions.Down, -5));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -13));
        //    expectedActions.Add(new cAction(Actions.Right, -12));
        //    expectedActions.Add(new cAction(Actions.Right, -11));
        //    expectedActions.Add(new cAction(Actions.Down, -10));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -18));
        //    expectedActions.Add(new cAction(Actions.Right, -17));
        //    expectedActions.Add(new cAction(Actions.Down, -16));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -15 - 9 - 25));
        //    expectedActions.Add(new cAction(Actions.None, -15 - 9 - 25));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_LineOfDustsWithBacktrack()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', 'D', 'D', 'D' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Up, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -7));
        //    expectedActions.Add(new cAction(Actions.Down, -6));
        //    expectedActions.Add(new cAction(Actions.Down, -5));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -13));
        //    expectedActions.Add(new cAction(Actions.Down, -12));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -20));
        //    expectedActions.Add(new cAction(Actions.Down, -19));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -18 - 9 - 25));
        //    expectedActions.Add(new cAction(Actions.None, -18 - 9 - 25));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_DustLeft()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(3, 3, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Left, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -32));
        //    expectedActions.Add(new cAction(Actions.None, -32));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_RecursiveDS_DustRight()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', 'D', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Right, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -32));
        //    expectedActions.Add(new cAction(Actions.None, -32));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}


        //[TestMethod]
        //public void T_RecursiveDS_DustAbove()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Up, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -32));
        //    expectedActions.Add(new cAction(Actions.None, -32));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}
        //[TestMethod]
        //public void T_RecursiveDS_DustBelow()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', 'D', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment environment = new cEnvironment(2, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    List<cAction> expectedActions = new List<cAction>();
        //    expectedActions.Add(new cAction(Actions.None, 0));
        //    expectedActions.Add(new cAction(Actions.Down, 1));
        //    expectedActions.Add(new cAction(Actions.Vacuum, -32));
        //    expectedActions.Add(new cAction(Actions.None, -32));

        //    //Act
        //    List<cAction> actionsList = new List<cAction>();
        //    actionsList.Add(new cAction(Actions.None, 0));
        //    List<cAction> bestActions = agent.RecursiveDS(actionsList, environment, 0, new List<cEnvironment>());

        //    foreach (var a in bestActions)
        //    {
        //        environment.MoveAgent(a.LatestAction);
        //        Console.WriteLine($"ACTION : {a.LatestAction.ToString()} {a.Cost.ToString()}");
        //        Console.WriteLine($"AGENT : ({environment.AgentPosX}, {environment.AgentPosY})");
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActions, bestActions);
        //}

        //[TestMethod]
        //public void T_TreeSearch_DustBelow()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', 'D', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(2, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Down,
        //        Actions.Vacuum
        //    };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_DustAbove()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(2, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Up,
        //        Actions.Vacuum
        //    };

        //    foreach (var item in actionList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine(goalNode.Action);

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_DustRight()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(1, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Right,
        //        Actions.Vacuum
        //    };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_DustLeft()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(3, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Left,
        //        Actions.Vacuum
        //    };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_LineOfDustsWithBacktrack()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', 'D', 'D', 'D' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', '*', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(2, 1, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Up,
        //        Actions.Vacuum,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.Vacuum,
        //        Actions.Down,
        //        Actions.Vacuum,
        //        Actions.Down,
        //        Actions.Vacuum,
        //    };

        //    //Assert
        //    foreach (var item in actionList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_Dusts()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', 'D', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', 'D' }
        //    };
        //    cEnvironment initialState = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Right,
        //        Actions.Vacuum,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.Vacuum,
        //        Actions.Right,
        //        Actions.Right,
        //        Actions.Down,
        //        Actions.Vacuum,
        //        Actions.Right,
        //        Actions.Down,
        //        Actions.Vacuum,
        //    };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_Mansion()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'*', '*', '*', '*', '*' },
        //        {'D', '*', 'B', '*', '*' },
        //        {'*', '*', '*', '*', '*' },
        //        {'*', '*', '*', 'D', '*' },
        //        {'*', '*', '*', '*', 'J' }
        //    };
        //    cEnvironment initialState = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Right,
        //        Actions.Vacuum,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.PickUp,
        //        Actions.Vacuum,
        //        Actions.Right,
        //        Actions.Right,
        //        Actions.Down,
        //        Actions.Vacuum,
        //        Actions.Right,
        //        Actions.Down,
        //        Actions.PickUp,
        //    };

        //    foreach (var item in actionList)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_Mansion2()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'J', 'D', '*', '*', '*' },
        //        {'*', '*', '*', 'J', '*' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', 'D', '*', 'B', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //        {
        //            Actions.PickUp,
        //            Actions.Down,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.Right,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.Right,
        //            Actions.Vacuum,
        //            Actions.Down,
        //            Actions.Left,
        //            Actions.PickUp,
        //            Actions.Right,
        //            Actions.Down,
        //            Actions.PickUp,
        //            Actions.Vacuum,
        //            Actions.Left,
        //            Actions.Left,
        //            Actions.Left,
        //            Actions.PickUp
        //        };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_Mansion3()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'J', '*', '*', '*', 'J' },
        //        {'*', '*', '*', '*', 'D' },
        //        {'*', 'D', '*', '*', '*' },
        //        {'*', '*', 'J', '*', '*' },
        //        {'*', 'D', '*', 'B', '*' }
        //    };
        //    cEnvironment initialState = new cEnvironment(2, 2, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //    {
        //        Actions.Right,
        //        Actions.PickUp,
        //        Actions.Down,
        //        Actions.Right,
        //        Actions.Down,
        //        Actions.PickUp,
        //        Actions.Vacuum,
        //        Actions.Up,
        //        Actions.Up,
        //        Actions.Vacuum,
        //        Actions.Left,
        //        Actions.Left,
        //        Actions.Vacuum,
        //        Actions.Left,
        //        Actions.Left,
        //        Actions.Up,
        //        Actions.PickUp,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.Down,
        //        Actions.PickUp,
        //        Actions.Right,
        //        Actions.Vacuum
        //    };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        //[TestMethod]
        //public void T_TreeSearch_Mansion4()
        //{
        //    //Arrange
        //    char[,] env = {
        //        {'J', 'D', 'D', 'D', 'B' },
        //        {'*', '*', '*', '*', 'D' },
        //        {'*', '*', 'D', 'D', 'D' },
        //        {'*', '*', 'D', '*', 'B' },
        //        {'*', '*', 'D', 'J', 'D' }
        //    };
        //    cEnvironment initialState = new cEnvironment(0, 0, env);
        //    cSmartAgent agent = new cSmartAgent();
        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    //Act
        //    cNode goalNode = agent.TreeSearch(rootNode, outsideBorder);
        //    List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
        //    List<Actions> expectedActionList = new List<Actions>
        //        {
        //            Actions.PickUp,
        //            Actions.Down,
        //            Actions.Vacuum,
        //            Actions.Down,
        //            Actions.Vacuum,
        //            Actions.Down,
        //            Actions.Vacuum,
        //            Actions.Down,
        //            Actions.PickUp,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.PickUp,
        //            Actions.Vacuum,
        //            Actions.Right,
        //            Actions.Vacuum,
        //            Actions.Up,
        //            Actions.PickUp,
        //            Actions.Vacuum,
        //            Actions.Up,
        //            Actions.Vacuum,
        //            Actions.Left,
        //            Actions.Vacuum,
        //            Actions.Left,
        //            Actions.Vacuum,
        //            Actions.Down,
        //            Actions.Vacuum
        //        };

        //    //Assert
        //    CollectionAssert.AreEqual(expectedActionList, actionList);
        //}

        [TestMethod]
        public void T_SuccessorFn_AllMovements_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_LeftWall_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_RightWall_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'B', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopWall_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' },
                {'B', 'D', 'B', '*', 'B' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopLeftCorner_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'B', '*', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' },
                {'B', 'D', 'B', '*', 'B' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopRightCorner_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'B', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomLeftCorner_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'B' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomRight_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomWall_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'B', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', 'B' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_AllMovements_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 1, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_LeftWall_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_RightWall_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopWall_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', 'D', 'D', '*', 'D' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopLeftCorner_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', 'D', 'D', '*', 'D' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopRightCorner_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'D', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomLeftCorner_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'D' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomRight_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomWall_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', 'D' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Vacuum
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_AllMovements_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 2, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_LeftWall_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'J', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_RightWall_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'J', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopWall_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', 'J', '*' },
                {'*', '*', '*', '*', '*' },
                {'J', 'D', 'J', '*', 'J' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopLeftCorner_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', 'J', '*' },
                {'*', '*', '*', '*', '*' },
                {'J', 'D', 'J', '*', 'J' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopRightCorner_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'J', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomLeftCorner_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomRight_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomWall_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'J', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', 'J' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.PickUp
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_AllMovements_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(1, 3, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Left,
                Actions.Up,
                Actions.Down
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);
            foreach (var item in successors)
            {
                Console.WriteLine(item);
            }

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_LeftWall_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Up,
                Actions.Down
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_RightWall_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Left,
                Actions.Up,
                Actions.Down,
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopWall_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Left,
                Actions.Down
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopLeftCorner_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Down
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_TopRightCorner_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Left,
                Actions.Down
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomLeftCorner_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Up
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomRight_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Left,
                Actions.Up
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_SuccessorFn_BottomWall_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            List<Actions> expectedSuccessors = new List<Actions>
            {
                Actions.Right,
                Actions.Left,
                Actions.Up
            };

            //Act
            List<Actions> successors = agent.SuccessorFn(environment);

            //Assert
            CollectionAssert.AreEqual(expectedSuccessors, successors);
        }

        [TestMethod]
        public void T_Expand_OnNothing()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cNode rootNode = new cNode(environment, Actions.None, 4);
            rootNode.RealCost = rootNode.ActionCost;

            cNode successorRight = new cNode(new cEnvironment(3, 2, env));
            cNode successorLeft = new cNode(new cEnvironment(1, 2, env));
            cNode successorUp = new cNode(new cEnvironment(2, 1, env));
            cNode successorDown = new cNode(new cEnvironment(2, 3, env));

            //Act
            List<cNode> successors = agent.Expand(rootNode);
            IEnumerable<cNode> sRight = successors.Where(s => (
                s.Action == Actions.Right &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 3 &&
                s.Environment.AgentPosY == 2 &&
                s.RealCost == 5 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));
            IEnumerable<cNode> sLeft = successors.Where(s => (
                s.Action == Actions.Left &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 1 &&
                s.Environment.AgentPosY == 2 &&
                s.RealCost == 5 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));
            IEnumerable<cNode> sUp = successors.Where(s => (
                s.Action == Actions.Up &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 2 &&
                s.Environment.AgentPosY == 1 &&
                s.RealCost == 5 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));
            IEnumerable<cNode> sDown = successors.Where(s => (
                s.Action == Actions.Down &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 2 &&
                s.Environment.AgentPosY == 3 &&
                s.RealCost == 5 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));

            //Assert
            Assert.IsTrue(successors.Count == 4, "Number of children");
            Assert.IsTrue(sRight.Count() == 1, "Right child");
            Assert.IsTrue(sLeft.Count() == 1, "Left child");
            Assert.IsTrue(sUp.Count() == 1, "Up child");
            Assert.IsTrue(sDown.Count() == 1, "Down child");
        }

        [TestMethod]
        public void T_Expand_OnDust()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cNode rootNode = new cNode(environment, Actions.None, 5);
            rootNode.RealCost = rootNode.ActionCost;

            cNode successorRight = new cNode(new cEnvironment(3, 2, env));
            cNode successorLeft = new cNode(new cEnvironment(1, 2, env));
            cNode successorUp = new cNode(new cEnvironment(2, 1, env));
            cNode successorDown = new cNode(new cEnvironment(2, 3, env));

            //Act
            List<cNode> successors = agent.Expand(rootNode);
            IEnumerable<cNode> sVacuum = successors.Where(s => (
                s.Action == Actions.Vacuum &&
                s.ActionCost == -8 &&
                s.Environment.AgentPosX == 2 &&
                s.Environment.AgentPosY == 2 &&
                s.RealCost == -3 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));

            //Assert
            Assert.IsTrue(successors.Count == 1, "Number of children");
            Assert.IsTrue(sVacuum.Count() == 1, "Vacuum child");
        }

        [TestMethod]
        public void T_Expand_OnJewel()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cNode rootNode = new cNode(environment, Actions.None, 5);
            rootNode.RealCost = rootNode.ActionCost;

            cNode successorRight = new cNode(new cEnvironment(3, 2, env));
            cNode successorLeft = new cNode(new cEnvironment(1, 2, env));
            cNode successorUp = new cNode(new cEnvironment(2, 1, env));
            cNode successorDown = new cNode(new cEnvironment(2, 3, env));

            //Act
            List<cNode> successors = agent.Expand(rootNode);
            IEnumerable<cNode> sPickup = successors.Where(s => (
                s.Action == Actions.PickUp &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 2 &&
                s.Environment.AgentPosY == 2 &&
                s.RealCost == 6 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));

            //Assert
            Assert.IsTrue(successors.Count == 1, "Number of children");
            Assert.IsTrue(sPickup.Count() == 1, "Pickup child");
        }

        [TestMethod]
        public void T_Expand_OnBoth()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cNode rootNode = new cNode(environment, Actions.None, -5);
            rootNode.RealCost = rootNode.ActionCost;

            cNode successorRight = new cNode(new cEnvironment(3, 2, env));
            cNode successorLeft = new cNode(new cEnvironment(1, 2, env));
            cNode successorUp = new cNode(new cEnvironment(2, 1, env));
            cNode successorDown = new cNode(new cEnvironment(2, 3, env));

            //Act
            List<cNode> successors = agent.Expand(rootNode);
            IEnumerable<cNode> sPickup = successors.Where(s => (
                s.Action == Actions.PickUp &&
                s.ActionCost == 1 &&
                s.Environment.AgentPosX == 2 &&
                s.Environment.AgentPosY == 2 &&
                s.RealCost == -4 &&
                s.Depth == 1 &&
                s.Parent == rootNode
            ));

            //Assert
            Assert.IsTrue(successors.Count == 1, "Number of children");
            Assert.IsTrue(sPickup.Count() == 1, "Pickup child");
        }

        [TestMethod]
        public void T_IterativeDeepening_DustBelow()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'D', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 1, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Down,
                Actions.Vacuum
            };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_DustAbove()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Up,
                Actions.Vacuum
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(goalNode.Action);

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_DustRight()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment initialState = new cEnvironment(1, 1, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.Vacuum
            };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_DustLeft()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment initialState = new cEnvironment(3, 1, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Left,
                Actions.Vacuum
            };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_LineOfDustsWithBacktrack()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'D', 'D', 'D' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 1, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Up,
                Actions.Vacuum,
                Actions.Down,
                Actions.Down,
                Actions.Vacuum,
                Actions.Down,
                Actions.Vacuum,
                Actions.Down,
                Actions.Vacuum,
            };

            //Assert
            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_Dusts()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'D', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment initialState = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.Vacuum,
                Actions.Down,
                Actions.Down,
                Actions.Vacuum,
                Actions.Right,
                Actions.Right,
                Actions.Down,
                Actions.Vacuum,
                Actions.Right,
                Actions.Down,
                Actions.Vacuum,
            };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_Mansion()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'B', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment initialState = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.Vacuum,
                Actions.Down,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Right,
                Actions.Right,
                Actions.Down,
                Actions.Vacuum,
                Actions.Right,
                Actions.Down,
                Actions.PickUp,
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_Mansion2()
        {
            //Arrange
            char[,] env = {
                {'J', 'D', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment initialState = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.PickUp,
                Actions.Down,
                Actions.Vacuum,
                Actions.Right,
                Actions.Right,
                Actions.Vacuum,
                Actions.Right,
                Actions.Right,
                Actions.Vacuum,
                Actions.Left,
                Actions.Down,
                Actions.PickUp,
                Actions.Right,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Left,
                Actions.Left,
                Actions.Left,
                Actions.Left,
                Actions.Down,
                Actions.PickUp
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_Mansion3()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', 'D' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.PickUp,
                Actions.Right,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Up,
                Actions.Up,
                Actions.Vacuum,
                Actions.Left,
                Actions.Left,
                Actions.Vacuum,
                Actions.Left,
                Actions.Left,
                Actions.Up,
                Actions.PickUp,
                Actions.Down,
                Actions.Down,
                Actions.Down,
                Actions.Down,
                Actions.PickUp,
                Actions.Right,
                Actions.Vacuum
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_IterativeDeepening_Mansion4()
        {
            //Arrange
            char[,] env = {
                {'J', 'D', 'D', 'D', 'B' },
                {'*', '*', '*', '*', 'D' },
                {'*', '*', 'D', 'D', 'D' },
                {'*', '*', 'D', '*', 'B' },
                {'*', '*', 'D', 'J', 'D' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            Queue<cNode> outsideBorder = new Queue<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            cNode goalNode = agent.IterativeDeepening(rootNode);
            List<Actions> actionList = agent.retrieveActionList(rootNode, goalNode);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.PickUp,
                Actions.Down,
                Actions.Vacuum,
                Actions.Down,
                Actions.Vacuum,
                Actions.Down,
                Actions.Vacuum,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Right,
                Actions.Vacuum,
                Actions.Right,
                Actions.Vacuum,
                Actions.Right,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Right,
                Actions.Vacuum,
                Actions.Up,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Up,
                Actions.Vacuum,
                Actions.Left,
                Actions.Vacuum,
                Actions.Left,
                Actions.Vacuum,
                Actions.Down,
                Actions.Vacuum
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }


            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_RecursiveDLS_Mansion()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'B', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment initialState = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<cNode> alreadyVisitedNodes = new List<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            Tuple<cNode, cSmartAgent.RecursiveDLStatus> result = agent.RecursiveDLS(rootNode, 12, alreadyVisitedNodes);
            Console.WriteLine(result.Item1 + " " + result.Item2);
            List<Actions> actionList = agent.retrieveActionList(rootNode, result.Item1);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.Vacuum,
                Actions.Down,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Right,
                Actions.Right,
                Actions.Down,
                Actions.Vacuum,
                Actions.Right,
                Actions.Down,
                Actions.PickUp,
            };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_RecursiveDLS_Mansion3_Depth0()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', 'D' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            List<cNode> alreadyVisitedNodes = new List<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            Tuple<cNode, cSmartAgent.RecursiveDLStatus> result = agent.RecursiveDLS(rootNode, 0, alreadyVisitedNodes);
            cSmartAgent.RecursiveDLStatus expectedStatus = cSmartAgent.RecursiveDLStatus.CUTOFF;

            //Assert
            Assert.AreEqual(expectedStatus, result.Item2);
        }

        [TestMethod]
        public void T_RecursiveDLS_Mansion3_Depth4()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', 'D' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            List<cNode> alreadyVisitedNodes = new List<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            Tuple<cNode, cSmartAgent.RecursiveDLStatus> result = agent.RecursiveDLS(rootNode, 4, alreadyVisitedNodes);
            cSmartAgent.RecursiveDLStatus expectedStatus = cSmartAgent.RecursiveDLStatus.CUTOFF;

            //Assert
            Assert.AreEqual(expectedStatus, result.Item2);
        }

        [TestMethod]
        public void T_RecursiveDLS_Mansion3_Depth22()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', 'D' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment initialState = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            List<cNode> alreadyVisitedNodes = new List<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            Tuple<cNode, cSmartAgent.RecursiveDLStatus> result = agent.RecursiveDLS(rootNode, 22, alreadyVisitedNodes);
            List<Actions> actionList = agent.retrieveActionList(rootNode, result.Item1);
            List<Actions> expectedActionList = new List<Actions>
            {
                Actions.Right,
                Actions.PickUp,
                Actions.Right,
                Actions.Down,
                Actions.PickUp,
                Actions.Vacuum,
                Actions.Up,
                Actions.Up,
                Actions.Vacuum,
                Actions.Left,
                Actions.Left,
                Actions.Vacuum,
                Actions.Left,
                Actions.Left,
                Actions.Up,
                Actions.PickUp,
                Actions.Down,
                Actions.Down,
                Actions.Down,
                Actions.Down,
                Actions.PickUp,
                Actions.Right,
                Actions.Vacuum
            };

            foreach (var item in actionList)
            {
                Console.WriteLine(item);
            }

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }

        [TestMethod]
        public void T_RecursiveDLS_Mansion4()
        {
            //Arrange
            char[,] env = {
                {'J', 'D', 'D', 'D', 'B' },
                {'*', '*', '*', '*', 'D' },
                {'*', '*', 'D', 'D', 'D' },
                {'*', '*', 'D', '*', 'B' },
                {'*', '*', 'D', 'J', 'D' }
            };
            cEnvironment initialState = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            List<cNode> alreadyVisitedNodes = new List<cNode>();

            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            //Act
            Tuple<cNode, cSmartAgent.RecursiveDLStatus> result = agent.RecursiveDLS(rootNode, 29, alreadyVisitedNodes);
            List<Actions> actionList = agent.retrieveActionList(rootNode, result.Item1);
            List<Actions> expectedActionList = new List<Actions>
                {
                    Actions.PickUp,
                    Actions.Down,
                    Actions.Vacuum,
                    Actions.Down,
                    Actions.Vacuum,
                    Actions.Down,
                    Actions.Vacuum,
                    Actions.Down,
                    Actions.PickUp,
                    Actions.Vacuum,
                    Actions.Right,
                    Actions.Vacuum,
                    Actions.Right,
                    Actions.Vacuum,
                    Actions.Right,
                    Actions.PickUp,
                    Actions.Vacuum,
                    Actions.Right,
                    Actions.Vacuum,
                    Actions.Up,
                    Actions.PickUp,
                    Actions.Vacuum,
                    Actions.Up,
                    Actions.Vacuum,
                    Actions.Left,
                    Actions.Vacuum,
                    Actions.Left,
                    Actions.Vacuum,
                    Actions.Down,
                    Actions.Vacuum
                };

            //Assert
            CollectionAssert.AreEqual(expectedActionList, actionList);
        }
    }
}
