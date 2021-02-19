using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AI_TD1;

namespace cTests
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
        public void T_CopyEnvironment_AgentDuplicated()
        {
            //Arrange
            cEnvironment environment1 = new cEnvironment(0, 0);

            //Act
            cEnvironment environment2 = environment1.CopyEnvironment();
            environment1.DoAgentAction(Actions.Right);

            //Assert
            Assert.IsTrue(environment2.AgentPosX == 0);
        }

        [TestMethod]
        public void T_CopyEnvironment_EnvironmentCopied()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment1 = new cEnvironment(0, 0, env);

            //Act
            cEnvironment environment2 = environment1.CopyEnvironment();

            //Assert
            CollectionAssert.AreEqual(environment2.Environment, env);
        }

        [TestMethod]
        public void T_CopyEnvironment_EnvironmentDuplicated()
        {
            //Arrange
            char[,] env = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'D', 'B', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment environment1 = new cEnvironment(0, 0, env);

            //Act
            cEnvironment environment2 = environment1.CopyEnvironment();
            environment1.DoAgentAction(Actions.Vacuum);

            //Assert
            CollectionAssert.AreNotEqual(
                environment2.Environment, 
                environment1.Environment
            );
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
            char[,] retVal = (char[,])obj.Invoke("InitialiseEnvironment");

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
            target.DoAgentAction(Actions.PickUp);

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
            target.DoAgentAction(Actions.PickUp);

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
            target.DoAgentAction(Actions.PickUp);

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
            target.DoAgentAction(Actions.PickUp);

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
            target.DoAgentAction(Actions.Right);

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
            target.DoAgentAction(Actions.Left);

            //Assert
            Assert.AreEqual(
                Tuple.Create(2, 2),
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_MoveAgent_None()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.DoAgentAction(Actions.None);

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
            target.DoAgentAction(Actions.Up);

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
            target.DoAgentAction(Actions.Down);

            //Assert
            Assert.AreEqual(
                Tuple.Create(3, 3),
                Tuple.Create(target.AgentPosX, target.AgentPosY)
            );

        }

        [TestMethod]
        public void T_MoveAgent_PickUp()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'J', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            //Act
            target.DoAgentAction(Actions.PickUp);

            //Assert
            Assert.AreNotEqual(target.Environment, currentEnvironment);
        }

        [TestMethod]
        public void T_MoveAgent_Vacuum()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            //Act
            target.DoAgentAction(Actions.Vacuum);

            //Assert
            Assert.AreNotEqual(target.Environment, currentEnvironment);
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
        public void T_GetAgentLocationStatus_Empty()
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

        [TestMethod]
        public void T_UpdateEnvironment_NoDrop()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] expectedEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.UpdateEnvironment(100000, 100000, 100000, 100000);

            //Assert
            CollectionAssert.AreEqual(target.Environment, expectedEnvironment);
        }

        [TestMethod]
        public void T_UpdateEnvironment_DustDropOnEmptyOrDust()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'D', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] expectedEnvironment = {
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.UpdateEnvironment(0, 4000, 100000, 100000);

            //Assert
            CollectionAssert.AreEqual(target.Environment, expectedEnvironment);
        }

        [TestMethod]
        public void T_UpdateEnvironment_JewelDropOnEmptyOrJewel()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' },
                {'J', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] expectedEnvironment = {
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.UpdateEnvironment(100000, 100000, 0, 1000);

            //Assert
            CollectionAssert.AreEqual(target.Environment, expectedEnvironment);
        }

        [TestMethod]
        public void T_UpdateEnvironment_DustDropOnJewel()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' },
                {'J', 'J', 'J', 'J', 'J' }
            };
            char[,] expectedEnvironment = {
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.UpdateEnvironment(0, 4000, 100000, 100000);

            //Assert
            CollectionAssert.AreEqual(target.Environment, expectedEnvironment);
        }

        [TestMethod]
        public void T_UpdateEnvironment_JewelDropOnDust()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' },
                {'D', 'D', 'D', 'D', 'D' }
            };
            char[,] expectedEnvironment = {
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' },
                {'B', 'B', 'B', 'B', 'B' }
            };
            cEnvironment target = new cEnvironment(2, 2, currentEnvironment);

            //Act
            target.UpdateEnvironment(100000, 100000, 0, 1000);

            //Assert
            CollectionAssert.AreEqual(target.Environment, expectedEnvironment);
        }

        [TestMethod]
        public void T_operatorEquality_SameObject()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, currentEnvironment);
            cEnvironment env2 = env1;

            //Act
            bool areEquals = (env2 == env1) && (env1 == env2);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_operatorEquality_Env1Null()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = null;
            cEnvironment env2 = new cEnvironment(2, 2, currentEnvironment);

            //Act
            bool areEquals = (env1 == env2) && (env2 == env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_operatorEquality_Env2Null()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, currentEnvironment);
            cEnvironment env2 = null;

            //Act
            bool areEquals = (env1 == env2) && (env2 == env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_operatorEquality_DifferentObjectsWithSameValues()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            cEnvironment env2 = new cEnvironment(2, 2, environment);

            //Act
            bool areEquals = (env1 == env2) && (env2 == env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_operatorEquality_DifferentObjectsWithDifferentValues()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            cEnvironment env2 = new cEnvironment(2, 3, environment);

            //Act
            bool areEquals = (env1 == env2) && (env2 == env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_operatorInequality_SameObject()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, currentEnvironment);
            cEnvironment env2 = env1;

            //Act
            bool areEquals = (env2 != env1) && (env1 != env2);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_operatorInequality_Env1Null()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = null;
            cEnvironment env2 = new cEnvironment(2, 2, currentEnvironment);

            //Act
            bool areEquals = (env1 != env2) && (env2 != env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_operatorInequality_Env2Null()
        {
            //Arrange
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, currentEnvironment);
            cEnvironment env2 = null;

            //Act
            bool areEquals = (env1 != env2) && (env2 != env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_operatorInequality_DifferentObjectsWithSameValues()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            cEnvironment env2 = new cEnvironment(2, 2, environment);

            //Act
            bool areEquals = (env1 != env2) && (env2 != env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_operatorInequality_DifferentObjectsWithDifferentValues()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            cEnvironment env2 = new cEnvironment(2, 3, environment);

            //Act
            bool areEquals = (env1 != env2) && (env2 != env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_Equals_SameObjects()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            cEnvironment env2 = env1;

            //Act
            bool areEquals = env1.Equals(env2) && env2.Equals(env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_Equals_Null()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env = new cEnvironment(2, 2, environment);

            //Act
            bool areEquals = env.Equals(null);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_Equals_DifferentObjectsWithSameValues()
        {
            //Arrange
            char[,] environment1 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] environment2 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment1);
            cEnvironment env2 = new cEnvironment(2, 2, environment2);

            //Act
            bool areEquals = env1.Equals(env2) && env2.Equals(env1);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_Equals_DifferentEnvironments()
        {
            //Arrange
            char[,] environment1 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] environment2 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'D', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment1);
            cEnvironment env2 = new cEnvironment(2, 2, environment2);

            //Act
            bool areEquals = env1.Equals(env2) && env2.Equals(env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_Equals_DifferentAgentPosX()
        {
            //Arrange
            char[,] environment1 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] environment2 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(4, 2, environment1);
            cEnvironment env2 = new cEnvironment(2, 2, environment2);

            //Act
            bool areEquals = env1.Equals(env2) && env2.Equals(env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_Equals_DifferentAgentPosY()
        {
            //Arrange
            char[,] environment1 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            char[,] environment2 = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment1);
            cEnvironment env2 = new cEnvironment(2, 4, environment2);

            //Act
            bool areEquals = env1.Equals(env2) && env2.Equals(env1);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_EqualsToObject_True()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            Object env2 = new cEnvironment(2, 2, environment);

            //Act
            bool areEquals = env1.Equals(env2);

            //Assert
            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void T_EqualsToObject_False()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };
            cEnvironment env1 = new cEnvironment(2, 2, environment);
            Object env2 = new char[25];

            //Act
            bool areEquals = env1.Equals(env2);

            //Assert
            Assert.IsFalse(areEquals);
        }

        [TestMethod]
        public void T_Heuristic_Clean()
        {
            //Arrange
            char[,] cleanEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };

            cEnvironment environment = new cEnvironment(0, 0, cleanEnvironment);
            int expectedDistance = 0;

            // Act
            int resultDistance = environment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }

        [TestMethod]
        public void T_Heuristic_OnStuff()
        {
            //Arrange
            char[,] cleanEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'D', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };

            cEnvironment environment = new cEnvironment(2, 3, cleanEnvironment);
            int expectedDistance = 1;

            // Act
            int resultDistance = environment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }

        [TestMethod]
        public void T_Heuristic_Dusts()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', 'D', '*', '*' },
                {'*', '*', 'D', '*', '*' },
                {'D', 'D', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' }
            };

            cEnvironment cEnvironment = new cEnvironment(0, 0, environment);
            int expectedDistance = 7;

            // Act
            int resultDistance = cEnvironment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }

        [TestMethod]
        public void T_Heuristic_Jewels()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', 'J' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', 'J', '*' },
                {'J', '*', '*', '*', '*' },
                {'*', '*', 'J', '*', '*' }
            };

            cEnvironment cEnvironment = new cEnvironment(2, 3, environment);
            int expectedDistance = 8;

            // Act
            int resultDistance = cEnvironment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }

        [TestMethod]
        public void T_Heuristic_Both()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', 'B', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', 'B', '*', 'B', '*' },
                {'*', '*', '*', '*', '*' }
            };

            cEnvironment cEnvironment = new cEnvironment(2, 2, environment);
            int expectedDistance = 10;

            // Act
            int resultDistance = cEnvironment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }


        [TestMethod]
        public void T_Heuristic_Multiple()
        {
            //Arrange
            char[,] environment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', 'D', '*', 'J' },
                {'*', 'J', '*', '*', '*' },
                {'*', '*', 'B', '*', '*' },
                {'B', '*', '*', '*', '*' }
            };

            cEnvironment cEnvironment = new cEnvironment(3, 3, environment);
            int expectedDistance = 11;

            // Act
            int resultDistance = cEnvironment.Heuristic();

            // Assert
            Assert.AreEqual(expectedDistance, resultDistance);
        }
    }
}
