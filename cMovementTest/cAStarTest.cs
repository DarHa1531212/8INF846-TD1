using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AI_TD1;

namespace cTests
{
    [TestClass]
    public class cAStarTest
    {
        [TestMethod]
        public void T_getLeastCostingNode_OneItemList()
        {
            // Arrange
            List<cNode> nodeList = new List<cNode>();
            cNode node1 = new cNode();
            node1.EstimatedCost = 40;
            node1.Environment = new cEnvironment(0, 0);
            nodeList.Add(node1);

            cNode expectedNode = new cNode();
            expectedNode.EstimatedCost = 40;
            expectedNode.Environment = new cEnvironment(0, 0);

            cSmartAgent agent = new cSmartAgent();

            // Act
            cNode resultNode = agent.GetLeastCostingNode(nodeList);

            // Assert
            Assert.IsTrue(expectedNode.Equals(resultNode));
        }

        [TestMethod]
        public void T_getLeastCostingNode_TwoItemsList()
        {
            // Arrange
            List<cNode> nodeList = new List<cNode>();
            cNode node1 = new cNode();
            node1.EstimatedCost = 40;
            node1.Environment = new cEnvironment(0, 0);
            nodeList.Add(node1);
            cNode node2 = new cNode();
            node2.EstimatedCost = 25;
            node2.Environment = new cEnvironment(4, 3);
            nodeList.Add(node2);

            cNode expectedNode = new cNode();
            expectedNode.EstimatedCost = 25;
            expectedNode.Environment = new cEnvironment(4, 3);

            cSmartAgent agent = new cSmartAgent();

            // Act
            cNode resultNode = agent.GetLeastCostingNode(nodeList);

            // Assert
            Assert.IsTrue(expectedNode.Equals(resultNode));
        }


        [TestMethod]
        public void T_generateSuccessors_AllMovements_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(2, 2, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(2, 2, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 2, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 2, env);
            cEnvironment upEnvironment = new cEnvironment(2, 1, env);
            cEnvironment downEnvironment = new cEnvironment(2, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_LeftWall_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 3, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 3, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 3, env);
            cEnvironment upEnvironment = new cEnvironment(0, 2, env);
            cEnvironment downEnvironment = new cEnvironment(0, 4, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_RightWall_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'B', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 1, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 1, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 1, env);
            cEnvironment upEnvironment = new cEnvironment(4, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 2, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_TopWall_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'B', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(2, 0, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(2, 0, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 0, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(2, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_BottomWall_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', 'B' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', 'D' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(3, 4, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(3, 4, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(2, 4, env);
            cEnvironment rightEnvironment = new cEnvironment(4, 4, env);
            cEnvironment upEnvironment = new cEnvironment(3, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_TopLeftCorner_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'B', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 0, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 0, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 0, env);
            cEnvironment downEnvironment = new cEnvironment(0, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_TopRight_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'B', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'D', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 0, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 0, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_BottomLeft_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'B' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', 'D' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 4, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 4, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 4, env);
            cEnvironment upEnvironment = new cEnvironment(0, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_BottomRight_OnBoth()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 4, vacuumedEnv);
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 4, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 4, env);
            cEnvironment upEnvironment = new cEnvironment(4, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 + 12));
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }



        [TestMethod]
        public void T_generateSuccessors_AllMovements_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(2, 2, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 2, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 2, env);
            cEnvironment upEnvironment = new cEnvironment(2, 1, env);
            cEnvironment downEnvironment = new cEnvironment(2, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_LeftWall_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 3, vacuumedEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 3, env);
            cEnvironment upEnvironment = new cEnvironment(0, 2, env);
            cEnvironment downEnvironment = new cEnvironment(0, 4, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_RightWall_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 1, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 1, env);
            cEnvironment upEnvironment = new cEnvironment(4, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 2, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_TopWall_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(2, 0, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 0, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(2, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_BottomWall_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', 'D' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(3, 4, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(2, 4, env);
            cEnvironment rightEnvironment = new cEnvironment(4, 4, env);
            cEnvironment upEnvironment = new cEnvironment(3, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_TopLeftCorner_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 0, vacuumedEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 0, env);
            cEnvironment downEnvironment = new cEnvironment(0, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_TopRight_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'D', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 0, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_BottomLeft_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'D' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(0, 4, vacuumedEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 4, env);
            cEnvironment upEnvironment = new cEnvironment(0, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_BottomRight_OnDust()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            char[,] vacuumedEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'D', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment vacuumedEnvironment = new cEnvironment(4, 4, vacuumedEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 4, env);
            cEnvironment upEnvironment = new cEnvironment(4, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(vacuumedEnvironment, Actions.Vacuum, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }



        [TestMethod]
        public void T_generateSuccessors_AllMovements_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(2, 2, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 2, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 2, env);
            cEnvironment upEnvironment = new cEnvironment(2, 1, env);
            cEnvironment downEnvironment = new cEnvironment(2, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_LeftWall_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', 'J', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 3, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 3, env);
            cEnvironment upEnvironment = new cEnvironment(0, 2, env);
            cEnvironment downEnvironment = new cEnvironment(0, 4, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_RightWall_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'J', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 1, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 1, env);
            cEnvironment upEnvironment = new cEnvironment(4, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 2, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_TopWall_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'J', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(2, 0, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(1, 0, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(2, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_BottomWall_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', 'J' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(3, 4, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(2, 4, env);
            cEnvironment rightEnvironment = new cEnvironment(4, 4, env);
            cEnvironment upEnvironment = new cEnvironment(3, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_TopLeftCorner_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'J', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 0, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 0, env);
            cEnvironment downEnvironment = new cEnvironment(0, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_TopRight_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'J', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 0, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_BottomLeft_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(0, 4, pickedUpEnv);
            cEnvironment rightEnvironment = new cEnvironment(1, 4, env);
            cEnvironment upEnvironment = new cEnvironment(0, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_BottomRight_OnJewel()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'J' }
            };
            char[,] pickedUpEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'J', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment pickedUpEnvironment = new cEnvironment(4, 4, pickedUpEnv);
            cEnvironment leftEnvironment = new cEnvironment(3, 4, env);
            cEnvironment upEnvironment = new cEnvironment(4, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(pickedUpEnvironment, Actions.PickUp, 1 - 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }




        [TestMethod]
        public void T_generateSuccessors_AllMovements_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(1, 2, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 2, env);
            cEnvironment upEnvironment = new cEnvironment(2, 1, env);
            cEnvironment downEnvironment = new cEnvironment(2, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_LeftWall_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 3, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment rightEnvironment = new cEnvironment(1, 3, env);
            cEnvironment upEnvironment = new cEnvironment(0, 2, env);
            cEnvironment downEnvironment = new cEnvironment(0, 4, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_RightWall_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(4, 1, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(3, 1, env);
            cEnvironment upEnvironment = new cEnvironment(4, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 2, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_TopWall_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(2, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(1, 0, env);
            cEnvironment rightEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(2, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_BottomWall_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(3, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(2, 4, env);
            cEnvironment rightEnvironment = new cEnvironment(4, 4, env);
            cEnvironment upEnvironment = new cEnvironment(3, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }
        [TestMethod]
        public void T_generateSuccessors_TopLeftCorner_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment rightEnvironment = new cEnvironment(1, 0, env);
            cEnvironment downEnvironment = new cEnvironment(0, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_TopRight_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(4, 0, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(3, 0, env);
            cEnvironment downEnvironment = new cEnvironment(4, 1, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(downEnvironment, Actions.Down, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_generateSuccessors_BottomLeft_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment environment = new cEnvironment(0, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment rightEnvironment = new cEnvironment(1, 4, env);
            cEnvironment upEnvironment = new cEnvironment(0, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(rightEnvironment, Actions.Right, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }


        [TestMethod]
        public void T_generateSuccessors_BottomRight_OnNothing()
        {
            // Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(4, 4, env);
            cSmartAgent agent = new cSmartAgent();
            cEnvironment leftEnvironment = new cEnvironment(3, 4, env);
            cEnvironment upEnvironment = new cEnvironment(4, 3, env);

            cNode baseNode = new cNode(environment);

            List<cNode> expectedNodes = new List<cNode>();
            expectedNodes.Add(new cNode(leftEnvironment, Actions.Left, 1));
            expectedNodes.Add(new cNode(upEnvironment, Actions.Up, 1));

            // Act
            List<cNode> resultSuccessors = agent.GenerateSuccessors(baseNode);

            // Assert
            CollectionAssert.AreEqual(expectedNodes, resultSuccessors);
        }

        [TestMethod]
        public void T_retrieveFirstAction_TwoNodes()
        {
            // Arrange
            cNode rootNode = new cNode(new cEnvironment(1, 3));
            rootNode.EstimatedCost = 40;

            cNode node1 = new cNode(new cEnvironment(1, 2), Actions.Up, 1);
            node1.EstimatedCost = 37;
            node1.Parent = rootNode;

            Actions expectedAction = Actions.Up;

            cSmartAgent agent = new cSmartAgent();
            // Act
            Actions resultAction = agent.RetrieveFirstAction(rootNode, node1);

            // Assert
            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_retrieveFirstAction_SeveralNodes()
        {
            // Arrange
            cNode rootNode = new cNode(new cEnvironment(1, 3));
            rootNode.EstimatedCost = 40;

            cNode node1 = new cNode(new cEnvironment(1, 2), Actions.Up, 1);
            node1.EstimatedCost = 37;
            node1.Parent = rootNode;

            cNode node2 = new cNode(new cEnvironment(1, 1), Actions.Up, 1);
            node2.EstimatedCost = 35;
            node2.Parent = node1;

            cNode node3 = new cNode(new cEnvironment(0, 2), Actions.Left, 1);
            node3.EstimatedCost = 36;
            node3.Parent = node1;

            cNode node4 = new cNode(new cEnvironment(2, 1), Actions.Right, 1);
            node4.EstimatedCost = 33;
            node4.Parent = node2;

            Actions expectedAction = Actions.Up;

            cSmartAgent agent = new cSmartAgent();
            // Act
            Actions resultAction = agent.RetrieveFirstAction(rootNode, node4);

            // Assert
            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_OnOneDust()
        {
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Vacuum;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_OnOneJewel()
        {
            char[,] env = {
                {'J', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.PickUp;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_OnBoth()
        {
            char[,] env = {
                {'B', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.PickUp;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_CleanBoard()
        {
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.None;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_RoomNextToDust()
        {
            char[,] env = {
                {'*', 'D', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Down;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_RoomNextToJewel()
        {
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(3, 3, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Up;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_RoomNextToBoth()
        {
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'B' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(1, 4, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Right;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_LineOfDusts()
        {
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'D', '*', '*', '*', '*' },
                {'D', '*', '*', '*', '*' },
                {'D', '*', '*', '*', '*' },
                {'D', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Right;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }


        [TestMethod]
        public void T_AStar_Dusts()
        {

            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'D', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment environment = new cEnvironment(0, 0, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Right;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }

        [TestMethod]
        public void T_AStar_LineOfDustsWithBacktrack()
        {
            //Arrange
            char[,] env = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', '*', 'D', 'D', 'D' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 1, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Up;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }
        
        [TestMethod]
        public void T_AStar_Mansion()
        {
            //Arrange
            char[,] env = {
                {'J', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', 'D' },
                {'*', 'D', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', 'D', '*', 'B', '*' }
            };
            cEnvironment environment = new cEnvironment(2, 2, env);
            cSmartAgent agent = new cSmartAgent();
            Actions expectedAction = Actions.Right;

            Actions resultAction = agent.AStar(environment);

            Assert.AreEqual(expectedAction, resultAction);
        }
    }

}
