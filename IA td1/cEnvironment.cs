using System;
using System.Linq;

namespace AI_TD1
{
    public class cEnvironment
    {
        #region Constants

        /// <summary>
        /// Average rate of dust drops (in turns)
        /// </summary>
        private const ushort _targetDustRate = 3;
        /// <summary>
        /// Average rate of jewel drops (in turns)
        /// </summary>
        private const ushort _targetJewelRate = 6;

        /// <summary>
        /// The dust drop RNG minimum limit
        /// </summary>
        private const int _dustDropRngMinLimit = 0;
        /// <summary>
        /// The dust drop RNG maximum limit
        /// </summary>
        private const int _dustDropRngMaxLimit = 100000;
        /// <summary>
        /// The jewels drop RNG minimum limit
        /// </summary>
        private const int _jewelsDropRngMinLimit = 0;
        /// <summary>
        /// The jewels drop RNG maximum limit
        /// </summary>
        private const int _jewelsDropRngMaxLimit = 100000;
        /// <summary>
        /// The board size
        /// </summary>
        private const int _boardSize = 5;
        /// <summary>
        /// The dust rate
        /// </summary>
        private const double _dustRate = 100000 / 25 / _targetDustRate;
        /// <summary>
        /// The jewel rate
        /// </summary>
        private const double _jewelRate = 100000 / 25 / _targetJewelRate;

        #endregion

        #region Attributes
        /// <summary>
        /// The penalty when vacuuming the jewel
        /// </summary>
        private const int penaltyVacuumJewel = 12;
        /// <summary>
        /// The dust vacuum bonus
        /// </summary>
        private const int bonusVacuumDust = 1;

        /// <summary>
        /// The bonus to pick up a jewel
        /// </summary>
        private const int bonusPickUpJewel = 1;

        /// <summary>
        /// The environment
        /// </summary>
        private char[,] environment;

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>
        /// The environment.
        /// </value>
        public char[,] Environment
        {
            get { return environment; }
        }
        /// <summary>
        /// Gets the agent position x.
        /// </summary>
        /// <value>
        /// The agent position x.
        /// </value>
        public int AgentPosX { get; private set; }
        /// <summary>
        /// Gets the agent position y.
        /// </summary>
        /// <value>
        /// The agent position y.
        /// </value>
        public int AgentPosY { get; private set; }

        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="cEnvironment"/> class.
        /// </summary>
        /// <param name="agentPosX">The agent position x.</param>
        /// <param name="agentPosY">The agent position y.</param>
        public cEnvironment(int agentPosX, int agentPosY)
        {
            this.AgentPosX = agentPosX;
            this.AgentPosY = agentPosY;
            environment = new char[_boardSize, _boardSize];
            environment = InitialiseEnvironment();
            UpdateEnvironment();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cEnvironment"/> class.
        /// </summary>
        /// <param name="agentPosX">The agent position x.</param>
        /// <param name="agentPosY">The agent position y.</param>
        /// <param name="env">The environment.</param>
        public cEnvironment(int agentPosX, int agentPosY, char[,] env) : this(agentPosX, agentPosY)
        {
            Array.Copy(env, this.Environment, env.GetLength(0) * env.GetLength(1));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates the environment.
        /// </summary>
        /// <param name="dustDropRngMinLimit">The dust drop RNG minimum limit.</param>
        /// <param name="dustDropRngMaxLimit">The dust drop RNG maximum limit.</param>
        /// <param name="jewelsDropRngMinLimit">The jewels drop RNG minimum limit.</param>
        /// <param name="jewelsDropRngMaxLimit">The jewels drop RNG maximum limit.</param>
        public void UpdateEnvironment(
            int dustDropRngMinLimit = _dustDropRngMinLimit,
            int dustDropRngMaxLimit = _dustDropRngMaxLimit,
            int jewelsDropRngMinLimit = _jewelsDropRngMinLimit,
            int jewelsDropRngMaxLimit = _jewelsDropRngMaxLimit
        )
        {
            char[,] tmpEnvironment = Environment;
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

            environment = tmpEnvironment;
        }

        /// <summary>
        /// Determines whether there is a jewel on the agent position.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if there is a jewel on the agent position; otherwise, <c>false</c>.
        /// </returns>
        private bool IsJewelOnAgentPosition()
        {
            if (Environment[AgentPosX, AgentPosY] == 'J' || Environment[AgentPosX, AgentPosY] == 'B')
                return true;
            return false;
        }


        /// <summary>
        /// Determines whether there is dust on agent position.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if there is dust on agent position; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDustOnAgentPosition()
        {
            if (Environment[AgentPosX, AgentPosY] == 'D' || Environment[AgentPosX, AgentPosY] == 'B')
                return true;
            return false;
        }
        /// <summary>
        /// Counts the vacuum action cost.
        /// </summary>
        /// <returns>The vacuum action cost.</returns>
        private int CountVacuumActionCost()
        {
            int cost = 0;
            if (IsJewelOnAgentPosition())
                return penaltyVacuumJewel;
            if (IsDustOnAgentPosition())
                return 0 - bonusVacuumDust;
            return cost;
        }

        /// <summary>
        /// Initialises the environment.
        /// </summary>
        /// <returns>The environment</returns>
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

        /// <summary>
        /// Picks up.
        /// </summary>
        /// <returns>The environment's state after pick up</returns>
        private Tuple<char, int> PickUp()
        {
            switch (Environment[AgentPosX, AgentPosY])
            {

                case 'B':
                    return new Tuple<char, int>('D', 0 - bonusPickUpJewel);
                case 'J':
                    return new Tuple<char, int>('*', 0 - bonusPickUpJewel);
                case 'D':
                    return new Tuple<char, int>('D', 0);
                default:
                    return new Tuple<char, int>('*', 0);
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Copies the environment.
        /// </summary>
        /// <returns>The copied environment</returns>
        public cEnvironment CopyEnvironment()
        {
            return new cEnvironment(AgentPosX, AgentPosY, environment);

        }

        /// <summary>
        /// The agent does an action
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The cost of the action</returns>
        public int DoAgentAction(Actions action)
        {
            switch (action)
            {
                case Actions.Right:
                    AgentPosX++;
                    return 1;
                case Actions.Left:
                    AgentPosX--;
                    return 1;
                case Actions.Up:
                    AgentPosY--;
                    return 1;
                case Actions.Down:
                    AgentPosY++;
                    return 1;
                case Actions.PickUp:
                    Tuple<char, int> pickup = PickUp();
                    Environment[AgentPosX, AgentPosY] = pickup.Item1;
                    return 1 + pickup.Item2;
                case Actions.Vacuum:
                    int vacuumActionCost = CountVacuumActionCost();
                    Environment[AgentPosX, AgentPosY] = '*';
                    return 1 + vacuumActionCost;
                default: // default action is None
                    return 0;
            }
        }

        /// <summary>
        /// Determines whether the potential is out of bounds.
        /// </summary>
        /// <param name="potentialAction">The potential action.</param>
        /// <returns>
        ///   <c>true</c> if the potential is out of bounds; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPotentialMoveOutOfBounds(Actions potentialAction)
        {
            cEnvironment potentialEnv = CopyEnvironment();
            potentialEnv.DoAgentAction(potentialAction);

            return !((potentialEnv.AgentPosX >= 0) && (potentialEnv.AgentPosX < _boardSize)
                && (potentialEnv.AgentPosY >= 0) && (potentialEnv.AgentPosY < _boardSize));
        }

        /// <summary>
        /// Determines whether this environment is clean.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this environment is clean; otherwise, <c>false</c>.
        /// </returns>
        public bool IsClean()
        {
            return !(HasDust() || HasJewels());
        }

        /// <summary>
        /// Determines whether this environment has dust.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this environment has dust; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Determines whether this environment has jewels.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this environment has jewels; otherwise, <c>false</c>.
        /// </returns>
        public bool HasJewels()
        {
            for (int X = 0; X < _boardSize; X++)
            {
                for (int Y = 0; Y < _boardSize; Y++)
                {
                    if (Environment[X, Y] == 'J' || Environment[X, Y] == 'B')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the agent's location status.
        /// </summary>
        /// <returns>The agent's location status.</returns>
        public char GetAgentLocationStatus()
        {
            return environment[AgentPosX, AgentPosY];
        }

        /// <summary>
        /// Draws the environment.
        /// </summary>
        public void DrawEnvironment()
        {
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
                    if (AgentPosY == Y && AgentPosX == X)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(Environment[X, Y]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write('|');
                Console.WriteLine();
            }

        }
        /// <summary>
        /// Compares this instance to the other instance.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>
        /// <c>true</c> if both instances are the same; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(cEnvironment other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.AgentPosX.Equals(other.AgentPosX)
                   && this.AgentPosY.Equals(other.AgentPosY)
                   && this.Environment.Cast<char>().SequenceEqual(other.Environment.Cast<char>());
        }

        /// <summary>
        /// Calculate the Manhattan distance
        /// </summary>
        /// <returns>The calculated distance</returns>
        public int Heuristic()
        {
            int objectCount = 0;
            int maxDistanceToSomething = 0;
            int distanceToStuff = 0;
            for (int i = 0; i < _boardSize; ++i)
            {
                for (int j = 0; j < _boardSize; ++j)
                {
                    if (environment[j, i] != '*')
                    {
                        objectCount += 1;
                        distanceToStuff = Math.Abs(AgentPosX - j) + Math.Abs(AgentPosY - i);
                        if(distanceToStuff > maxDistanceToSomething)
                        {
                            maxDistanceToSomething = distanceToStuff;
                        }
                    }
                    if(environment[i,j] == 'B')
                    {
                        objectCount += 1;
                    }
                }
            }
            return objectCount + maxDistanceToSomething;
        }
        #endregion

        #region Operators
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="env1">The env1.</param>
        /// <param name="env2">The env2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(cEnvironment env1, cEnvironment env2)
        {
            if (ReferenceEquals(env1, env2))
            {
                return true;
            }
            if (ReferenceEquals(env1, null))
            {
                return false;
            }
            if (ReferenceEquals(env2, null))
            {
                return false;
            }

            return env1.Equals(env2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="env1">The env1.</param>
        /// <param name="env2">The env2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(cEnvironment env1, cEnvironment env2)
        {
            return !(env1 == env2);
        }


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as cEnvironment);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = AgentPosX.GetHashCode();
                hashCode = (hashCode * 397) ^ AgentPosY.GetHashCode();
                hashCode = (hashCode * 397) ^ environment.GetHashCode();
                return hashCode;
            }
        }
        #endregion
    }
}
