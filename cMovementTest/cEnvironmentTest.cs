﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI_TD1;

namespace cMovementTest
{
    /// <summary>
    /// Description résumée pour cEnvironmentTest
    /// </summary>
    [TestClass]
    public class cEnvironmentTest
    {
        public cEnvironmentTest()
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

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void T_EnvironmentCopy()
        {
            //Arrange
            cEnvironment environment1 = new cEnvironment(0, 0);

            //Act
            cEnvironment environment2 = environment1.CopyEnvironment();
            environment1.MoveAgent(Actions.Right);

            //Assert

            Assert.IsTrue(environment2.AgentPosX == 0);
        }

        [TestMethod]
        public void T_EnvironmentCopy_TestingOnBoard()
        {
            //Arrange
            char[,] tempEnv = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };

            cEnvironment environment1 = new cEnvironment(0, 0, tempEnv);

            //Act
            cEnvironment environment2 = environment1.CopyEnvironment();
            environment1.MoveAgent(Actions.Vacuum);

            //Assert

            Assert.IsTrue(environment2.Environment[0, 0] == 'D');
        }

        [TestMethod]
        public void T_InitializeEnvironment()
        {
            //Arrange
            char[,] emptyEnv = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };

            // Act
            cEnvironment target = new cEnvironment(0, 0);
            PrivateObject obj = new PrivateObject(target);
            char[,] retVal = (char[,])obj.Invoke("InitialiseEnvironnement");

            // Assert
            CollectionAssert.AreEqual(emptyEnv, retVal);
        }

        [TestMethod]
        public void T_PickUp_Both()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'B', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            //Act
            target.MoveAgent(Actions.PickUp);

            //Assert
            Assert.AreEqual('D', target.Environment[0, 0]);

        }

        [TestMethod]
        public void T_PickUp_Dust()
        {
            // Arrange
            char[,] currentEnvironment = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            // Act
            target.MoveAgent(Actions.PickUp);

            // Assert
            Assert.AreEqual('D', target.Environment[0, 0]);

        }

        [TestMethod]
        public void T_PickUp_Jewel()
        {
            // Arrange
            char[,] currentEnvironment = {
                {'J', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            // Act
            target.MoveAgent(Actions.PickUp);

            // Assert
            Assert.AreEqual('*', target.Environment[0, 0]);

        }

        [TestMethod]
        public void T_PickUp_Empty()
        {
            // Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            // Act
            target.MoveAgent(Actions.PickUp);

            // Assert
            Assert.AreEqual('*', target.Environment[0, 0]);

        }

        [TestMethod]
        public void T_MoveAgent_Right()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            //Act
            target.MoveAgent(Actions.Right);

            //Assert
            Assert.AreEqual(
                Tuple.Create(1, 0), 
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_MoveAgent_Left()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(3, 2, currentEnvironment);

            //Act
            target.MoveAgent(Actions.Left);

            //Assert
            Assert.AreEqual(
                Tuple.Create(2, 2),
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_MoveAgent_Up()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(3, 2, currentEnvironment);

            //Act
            target.MoveAgent(Actions.Up);

            //Assert
            Assert.AreEqual(
                Tuple.Create(3, 1),
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_MoveAgent_Down()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(3, 2, currentEnvironment);

            //Act
            target.MoveAgent(Actions.Down);

            //Assert
            Assert.AreEqual(
                Tuple.Create(3, 3),
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Up_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(2, 0, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Up);

            //Assert
            Assert.IsTrue(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Up_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Up);

            //Assert
            Assert.IsFalse(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Down_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(2, 4, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Down);

            //Assert
            Assert.IsTrue(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Down_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(4, 0, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Down);

            //Assert
            Assert.IsFalse(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Left_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Left);

            //Assert
            Assert.IsTrue(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Left_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(4, 0, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Left);

            //Assert
            Assert.IsFalse(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Right_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(4, 0, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Right);

            //Assert
            Assert.IsTrue(isOutOfBounds);
        }

        [TestMethod]
        public void T_IsPotentialMoveOutOfBounds_Right_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool isOutOfBounds = target.IsPotentialMoveOutOfBounds(Actions.Right);

            //Assert
            Assert.IsFalse(isOutOfBounds);
        }

        [TestMethod]
        public void T_HasDust_Dust_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'D' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool result = target.HasDust();

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void T_HasDust_Both_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'B', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'B' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool result = target.HasDust();

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void T_HasDust_BothAndDust_True()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'D' },
                {'*', '*', '*', '*', '*' },
                {'B', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool result = target.HasDust();

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void T_HasDust_Jewel_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool result = target.HasDust();

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void T_HasDust_None_False()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 4, currentEnvironment);

            //Act
            bool result = target.HasDust();

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void T_GetAgentLocationStatus_Jewel()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'B', '*', 'D' }
            };
            cEnvironment target = new cEnvironment(2, 4, currentEnvironment);

            //Act
            char result = target.GetAgentLocationStatus();

            //Assert
            Assert.AreEqual('J', result);

        }

        [TestMethod]
        public void T_GetAgentLocationStatus_Dust()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'B', '*', 'D' }
            };
            cEnvironment target = new cEnvironment(4, 4, currentEnvironment);

            //Act
            char result = target.GetAgentLocationStatus();

            //Assert
            Assert.AreEqual('D', result);

        }

        [TestMethod]
        public void T_GetAgentLocationStatus_Both()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'B', '*', 'D' }
            };
            cEnvironment target = new cEnvironment(4, 2, currentEnvironment);

            //Act
            char result = target.GetAgentLocationStatus();

            //Assert
            Assert.AreEqual('B', result);

        }

        [TestMethod]
        public void T_GetAgentLocationStatus_None()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'B', '*', 'D' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            char result = target.GetAgentLocationStatus();

            //Assert
            Assert.AreEqual('*', result);

        }

    }
}
