using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validresponse = false;

            while (!validresponse) { 
                Console.WriteLine("1 pour agent non informé");
                Console.WriteLine("2 pour un agent informé");
                int result = Console.Read();

                if (result == 49)
                {
                    Console.WriteLine("uninformed");
                    validresponse = true;
                }
                else if (result == 50)
                {
                    Console.WriteLine("Informed");
                    validresponse = true;
                }
                else
                {
                    Console.WriteLine("Wrong carracter, try again");
                }
            }

            cEnvironment mansion = new cEnvironment();
            mansion.drawEnvironnement();
            cSmartAgent agent = new cSmartAgent(mansion);
         
        }
    }
}
