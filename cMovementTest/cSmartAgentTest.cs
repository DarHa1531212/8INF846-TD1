﻿using System;
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

        [TestMethod]
        public void T_FindValidMoves_AllMovements_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_LeftWall_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_RightWall_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopWall_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 7));
            expectedValidActions.Add(new cAction(Actions.PickUp, 2));
            expectedValidActions.Add(new cAction(Actions.Right, 2));
            expectedValidActions.Add(new cAction(Actions.Left, 2));
            expectedValidActions.Add(new cAction(Actions.Down, 2));

            //Act
            List<cAction> validActions = agent.FindValidActions(1, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopLeftCorner_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopRightCorner_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomLeftCorner_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomRight_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 6));
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomWall_OnBoth()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 10));
            expectedValidActions.Add(new cAction(Actions.PickUp, 5));
            expectedValidActions.Add(new cAction(Actions.Right, 5));
            expectedValidActions.Add(new cAction(Actions.Left, 5));
            expectedValidActions.Add(new cAction(Actions.Up, 5));

            //Act
            List<cAction> validActions = agent.FindValidActions(4, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_AllMovements_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 4));
            expectedValidActions.Add(new cAction(Actions.Right, 4));
            expectedValidActions.Add(new cAction(Actions.Left, 4));
            expectedValidActions.Add(new cAction(Actions.Down, 4));
            expectedValidActions.Add(new cAction(Actions.Up, 4));

            //Act
            List<cAction> validActions = agent.FindValidActions(3, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_LeftWall_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_RightWall_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopWall_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 2));
            expectedValidActions.Add(new cAction(Actions.Right, 2));
            expectedValidActions.Add(new cAction(Actions.Left, 2));
            expectedValidActions.Add(new cAction(Actions.Down, 2));

            //Act
            List<cAction> validActions = agent.FindValidActions(1, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopLeftCorner_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopRightCorner_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomLeftCorner_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomRight_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomWall_OnDust()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Vacuum, 5));
            expectedValidActions.Add(new cAction(Actions.Right, 5));
            expectedValidActions.Add(new cAction(Actions.Left, 5));
            expectedValidActions.Add(new cAction(Actions.Up, 5));

            //Act
            List<cAction> validActions = agent.FindValidActions(4, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_AllMovements_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 2));
            expectedValidActions.Add(new cAction(Actions.Right, 2));
            expectedValidActions.Add(new cAction(Actions.Left, 2));
            expectedValidActions.Add(new cAction(Actions.Down, 2));
            expectedValidActions.Add(new cAction(Actions.Up, 2));

            //Act
            List<cAction> validActions = agent.FindValidActions(1, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_LeftWall_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_RightWall_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopWall_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 2));
            expectedValidActions.Add(new cAction(Actions.Right, 2));
            expectedValidActions.Add(new cAction(Actions.Left, 2));
            expectedValidActions.Add(new cAction(Actions.Down, 2));

            //Act
            List<cAction> validActions = agent.FindValidActions(1, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopLeftCorner_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopRightCorner_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomLeftCorner_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomRight_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomWall_OnJewel()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.PickUp, 5));
            expectedValidActions.Add(new cAction(Actions.Right, 5));
            expectedValidActions.Add(new cAction(Actions.Left, 5));
            expectedValidActions.Add(new cAction(Actions.Up, 5));

            //Act
            List<cAction> validActions = agent.FindValidActions(4, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_AllMovements_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_LeftWall_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_RightWall_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopWall_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 2));
            expectedValidActions.Add(new cAction(Actions.Left, 2));
            expectedValidActions.Add(new cAction(Actions.Down, 2));

            //Act
            List<cAction> validActions = agent.FindValidActions(1, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopLeftCorner_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_TopRightCorner_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Down, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomLeftCorner_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomRight_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Left, 1));
            expectedValidActions.Add(new cAction(Actions.Up, 1));

            //Act
            List<cAction> validActions = agent.FindValidActions(0, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }

        [TestMethod]
        public void T_FindValidMoves_BottomWall_OnNothing()
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
            List<cAction> expectedValidActions = new List<cAction>();
            expectedValidActions.Add(new cAction(Actions.Right, 5));
            expectedValidActions.Add(new cAction(Actions.Left, 5));
            expectedValidActions.Add(new cAction(Actions.Up, 5));

            //Act
            List<cAction> validActions = agent.FindValidActions(4, environment);

            //Assert
            CollectionAssert.AreEqual(validActions, expectedValidActions);
        }
    }
}