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
        #region Constants

        private const int _dustDropRngMinLimit = 0;
        private const int _dustDropRngMaxLimit = 100000;
        private const int _jewelsDropRngMinLimit = 0;
        private const int _jewelsDropRngMaxLimit = 100000;
        private const int _boardSize = 5;

        private const double _dustRate = 100000 / 25 / 1;
        private const double _jewelRate = 100000 / 25 / 4;

        #endregion

        #region Private attributes
        private char[,] environment;
        public char[,] Environment
        {
            get { return environment; }

        }
        public int AgentPosX { get => agentPosX; }
        public int AgentPosY { get => agentPosY; }

        private int agentPosX;
        private int agentPosY;

        #endregion

        #region Ctor
        public cEnvironment(int agentPosX, int agentPosY)
        {
            this.agentPosX = agentPosX;
            this.agentPosY = agentPosY;
            environment = new char[_boardSize, _boardSize];
            environment = InitialiseEnvironment();
            UpdateEnvironment();
        }

        public cEnvironment(int agentPosX, int agentPosY, char[,] env) : this(agentPosX, agentPosY)
        {
            Array.Copy(env, this.Environment, env.GetLength(0) * env.GetLength(1));
        }

        #endregion

        #region Private Methods

        public void UpdateEnvironment(
            int dustDropRngMinLimit = _dustDropRngMinLimit,
            int dustDropRngMaxLimit = _dustDropRngMaxLimit,
            int jewelsDropRngMinLimit = _jewelsDropRngMinLimit,
            int jewelsDropRngMaxLimit = _jewelsDropRngMaxLimit
        )
        {
            char[,] tmpEnvironment = Environment;
            cSmartAgent tempAgent = new cSmartAgent();
            double rng;
            Random r = new Random();

            for (int x = 0; x < _boardSize; x++)
            {
                for (int y = 0; y < _boardSize; y++)
                {
                    //testing dust drop
                    rng = r.Next(dustDropRngMinLimit, dustDropRngMaxLimit);

                    if (rng <= _dustRate)
                    {
                        if (tmpEnvironment[x, y] == 'J')
                            tmpEnvironment[x, y] = 'B';
                        else
                            tmpEnvironment[x, y] = 'D';
                    }

                    //testing diamond drop
                    rng = r.Next(jewelsDropRngMinLimit, jewelsDropRngMaxLimit);
                    if (rng <= _jewelRate)
                    {
                        if (tmpEnvironment[x, y] == 'D')
                            tmpEnvironment[x, y] = 'B';
                        else
                            tmpEnvironment[x, y] = 'J';
                    }
                }
            }
            tempAgent.AgentCanMoove = true;

            environment = tmpEnvironment;
        }

        private char[,] InitialiseEnvironment()
        {
            char[,] tempEnv = new char[_boardSize, _boardSize];

            for (int x = 0; x < _boardSize; x++)
            {
                for (int y = 0; y < _boardSize; y++)
                {
                    tempEnv[x, y] = '*';
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
                //TODO add test for action NONE
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
                default:
                    break;
            }
        }

        public bool IsPotentialMoveOutOfBounds(Actions potentialAction)
        {
            //todo create test to validate copy of cEnvironment object
            cEnvironment potentialEnv = CopyEnvironment();
            potentialEnv.MoveAgent(potentialAction);

            return !((potentialEnv.AgentPosX >= 0) && (potentialEnv.AgentPosX < _boardSize)
                && (potentialEnv.AgentPosY >= 0) && (potentialEnv.AgentPosY < _boardSize));
        }

        public bool HasDust()
        {
            for (int X = 0; X < _boardSize; X++)
            {
                for (int Y = 0; Y < _boardSize; Y++)
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

        public void DrawEnvironment()
        {
            cSmartAgent tempAgent = new cSmartAgent();
            int agentLocationX = tempAgent.LocationX;
            int agentLocationY = tempAgent.LocationY;

            Console.Clear();
            Console.SetCursorPosition(6, 1);
            Console.WriteLine("|0|1|2|3|4|");

            for (int Y = 0; Y < _boardSize; Y++)
            {
                Console.SetCursorPosition(_boardSize, 2 + Y);

                Console.Write(Y);
                for (int X = 0; X < _boardSize; X++)
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
