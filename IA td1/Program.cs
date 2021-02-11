using System;
using System.Threading;
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

            /* bool validresponse = false;

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
             }*/

            //todo remove testing parameters
            char[,] currentEnvironment = {
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'*', '*', '*', '*', '*' },
                {'D', '*', '*', '*', '*' }
            };
            cEnvironment target = new cEnvironment(0, 0, currentEnvironment);

            
            
            cEnvironment mansion = new cEnvironment(0, 0);

            //Testing

            Thread environmentThread = new Thread(() => UpdateEnvironmentLoop(target));
            environmentThread.Start();

            cSmartAgent agent = new cSmartAgent(target);
            

        }

        public static void UpdateEnvironmentLoop(cEnvironment environment)
        {
            while (true)
            {
                Thread.Sleep(1500);
                //TODO remove testing parameters
                //environment.UpdateEnvironment();

                environment.UpdateEnvironment(100000, 100000, 100000, 100000);

                environment.DrawEnvironment();
                
            }
        }
    }
}
