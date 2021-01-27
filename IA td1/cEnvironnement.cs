using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_td1
{
    class cEnvironnement
    {
        private const double dustRate = 100000 / 25 / 1;
        private const double diamondRate = 100000 / 25 / 4;

        private char[,] environnemen;


        public char[,] Environnement {
            get { return environnemen; }
            set { environnemen = value; }
        }

        public cEnvironnement()
        {
            environnemen = new char[5, 5];
            environnemen = InitialiseEnvironnement();

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

        public void drawEnvironnement()
        {
            cSmartAgent tempAgent = new cSmartAgent();
            int[] agentLocation = tempAgent.Location;


            Console.Clear();
            Console.SetCursorPosition(6, 1);
            Console.WriteLine("|0|1|2|3|4|");
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(5, 2 + i);

                Console.Write(i);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write('|');
                    Console.Write(environnemen[i, j]);
                }
                Console.Write('|');
                Console.WriteLine();
            }

        }


    }
}
