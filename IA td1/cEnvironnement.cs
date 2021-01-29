using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cEnvironnement
    {
        #region Ctor
        private const double dustRate = 100000 / 25 / 1;
        private const double diamondRate = 100000 / 25 / 4;

        public char[,] Environnement { get; set; }

        public cEnvironnement()
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
                        Console.WriteLine("dustRate!");
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
