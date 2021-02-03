using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cEnvironment
    {
        #region Ctor
        private const double dustRate = 100000 / 25 / 1;
        private const double diamondRate = 100000 / 25 / 4;

        public char[,] Environnement { get; }
        public int AgentPosX { get => agentPosX;}
        public int AgentPosY { get => agentPosY;}

        private int agentPosX;
        private int agentPosY;

        public cEnvironment()
        {
            Environnement = new char[5, 5];
            Environnement = InitialiseEnvironnement();
            while (true)
            {
                Thread.Sleep(1500);
                Environnement = UpdateEnvironnement();
                drawEnvironnement();
            }

        }

        #endregion

        #region Private Methods

        private char[,] UpdateEnvironnement()
        {
            char[,] tempEnvironnemen = Environnement;
            cSmartAgent tempAgent = new cSmartAgent();
            double rng;
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //testing dust drop
                    rng = r.Next(0, 100000);

                    if (rng <= dustRate)
                    {
                        if (tempEnvironnemen[i, j] == 'J')
                            tempEnvironnemen[i, j] = 'B';
                        else
                            tempEnvironnemen[i, j] = 'D';
                    }

                    //testing diamond drop
                    rng = r.Next(0, 100000);
                    if (rng <= diamondRate)
                    {
                        if (tempEnvironnemen[i, j] == 'D')
                            tempEnvironnemen[i, j] = 'B';

                        else
                            tempEnvironnemen[i, j] = 'J';

                    }

                }
            }
            tempAgent.AgentCanMoove = true;
            return tempEnvironnemen;
        }

        private char[,] InitialiseEnvironnement()
        {
            char[,] tempEnvironnemen = new char[5, 5];
            double rng;
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tempEnvironnemen[i, j] = '*';
                }
            }

            //TODO refactor this function
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //testing dust drop
                    rng = r.Next(0, 100000);

                    if (rng <= dustRate)
                    {
                        tempEnvironnemen[i, j] = 'D';
                    }

                    //testing diamond drop
                    rng = r.Next(0, 100000);
                    if (rng <= diamondRate)
                    {
                        if (tempEnvironnemen[i, j] != 'D')
                            tempEnvironnemen[i, j] = 'J';

                        else
                            tempEnvironnemen[i, j] = 'B';

                    }

                }
            }
            return tempEnvironnemen;

        }
        #endregion

        #region Public Methods
        public void MoveAgent(cActionsEnum.Actions move)
        {
            switch (move) {

                case cActionsEnum.Actions.Right: agentPosX++;
                    break;
                case cActionsEnum.Actions.Left: agentPosX--;
                    break;
                case cActionsEnum.Actions.Up: agentPosY--;
                    break;
                case cActionsEnum.Actions.Down: agentPosY++;
                    break;
                case cActionsEnum.Actions.PickUp: Console.WriteLine("PickUp");
                    break;
                case cActionsEnum.Actions.Vacuum: Console.WriteLine("Vacuum");
                    break;
            }
        }

        public bool IsOutOfBounds(int x, int y)
        {
            int bound = 5;
            return (x >= 0) && (x < bound) && (y >= 0) && (y < bound);
        }

        public bool HasDust()
        {
            for (int X = 0; X < 5; X++)
            {
                for (int Y = 0; Y < 5; Y++)
                {
                    if (Environnement[X, Y] == 'D' || Environnement[X, Y] == 'B')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsAgentOnDust() 
        {
            return Environnement[agentPosX, agentPosY] == 'D' || Environnement[agentPosX, agentPosY] == 'B';
        }

        public bool IsAgentOnJewel() 
        {
            return Environnement[agentPosX, agentPosY] == 'J' || Environnement[agentPosX, agentPosY] == 'B';
        }

        public void drawEnvironnement()
        {
            cSmartAgent tempAgent = new cSmartAgent();
            int agentLocationX = tempAgent.LocationX;
            int agentLocationY = tempAgent.LocationY;
            


            Console.Clear();
            Console.SetCursorPosition(6, 1);
            Console.WriteLine("|0|1|2|3|4|");

            for (int Y = 0; Y < 5; Y++)
            {
                Console.SetCursorPosition(5, 2 + Y);

                Console.Write(Y);
                for (int X = 0; X < 5; X++)
                {
                    Console.Write('|');
                    if (agentLocationY == Y && agentLocationX == X)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(Environnement[Y, X]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write('|');
                Console.WriteLine();
            }

        }
        #endregion

    }
}
