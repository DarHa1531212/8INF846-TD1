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

        private char[,] environment;
        public char[,] Environment
        {
            get { return environment; }

        }
        public int AgentPosX { get => agentPosX; }
        public int AgentPosY { get => agentPosY; }

        private int agentPosX;
        private int agentPosY;

        public cEnvironment(int agentPosX, int agentPosY)
        {
            this.agentPosX = agentPosX;
            this.agentPosY = agentPosY;
            environment = new char[5, 5];
            environment = InitialiseEnvironnement();
            UpdateEnvironnement();

        }

        public cEnvironment(int agentPosX, int agentPosY, char[,] env) : this(agentPosX, agentPosY)
        {
            Array.Copy(env, this.Environment, env.GetLength(0) * env.GetLength(1));
        }

        #endregion

        #region Private Methods

        public void UpdateEnvironnement()
        {
            char[,] tempEnvironnemen = Environment;
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

            environment = tempEnvironnemen;
        }

        private char[,] InitialiseEnvironnement()
        {
            char[,] tempEnv = new char[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tempEnv[i, j] = '*';
                }
            }
            return tempEnv;
        }

        private char PickUp()
        {
            switch (Environment[agentPosX, agentPosY])
            {

                case 'B': return 'D';
                case 'J': return '*';
                case 'D': return 'D';
                default: return '*';
            }
        }
        #endregion

        #region Public Methods

        public cEnvironment CopyEnvironment()
        {
            return new cEnvironment(AgentPosX, AgentPosY, environment);

        }

        public void MoveAgent(Actions move)
        {
            switch (move)
            {
                //TODO add penalty points for vacuuming jewel
                case Actions.Right:
                    agentPosX++;
                    break;
                case Actions.Left:
                    agentPosX--;
                    break;
                case Actions.Up:
                    agentPosY--;
                    break;
                case Actions.Down:
                    agentPosY++;
                    break;
                case Actions.PickUp:
                    Environment[agentPosX, agentPosY] = PickUp();
                    break;
                case Actions.Vacuum:
                    Environment[agentPosX, agentPosY] = '*';
                    break;
            }
        }

        public bool IsPotentialMoveOutOfBounds(Actions potentialAction)
        {
            //todo create test to validate copy of cEnvironment object
            int bound = 5;
            cEnvironment potentialEnv = CopyEnvironment();
            potentialEnv.MoveAgent(potentialAction);

            return !((potentialEnv.AgentPosX >= 0) && (potentialEnv.AgentPosX < bound)
                && (potentialEnv.AgentPosY >= 0) && (potentialEnv.AgentPosY < bound));
        }

        public bool HasDust()
        {
            for (int X = 0; X < 5; X++)
            {
                for (int Y = 0; Y < 5; Y++)
                {
                    if (Environment[X, Y] == 'D' || Environment[X, Y] == 'B')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public char GetAgentLocationStatus()
        {
            return environment[agentPosX, agentPosY];
        }

        public void DrawEnvironnement()
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
                    Console.Write(Environment[Y, X]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write('|');
                Console.WriteLine();
            }

        }
        #endregion

    }
}
