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
        private static cEnvironment mansion = new cEnvironment(2, 2);
        private static bool agentCanMove = false;
        private static bool environmentCanUpdate = true;

        static void Main(string[] args)
        {
             bool validresponse = false;
             bool isInformed = false;

             while (!validresponse) { 
                 Console.WriteLine("Type 1 to execute an non informed agent");
                 Console.WriteLine("Type 2 to execute an informed agent");
                 int result = Console.Read();

                 if (result == 49)
                 {
                    isInformed = false;
                    validresponse = true;
                    Console.WriteLine("Chosen agent : Non informed");
                }
                 else if (result == 50)
                 {
                    isInformed = true;
                    validresponse = true;
                    Console.WriteLine("Chosen agent : Informed");
                }
                 else
                 {
                     Console.WriteLine("Wrong character, try again");
                 }
             }
            
            Thread environmentThread = new Thread(() => UpdateEnvironmentLoop());
            environmentThread.Start();

            cSmartAgent agent = new cSmartAgent(isInformed);

            while (true)
            {
                if(agentCanMove)
                {
                    cEnvironment updatedMansion = agent.lifeCycle(mansion);
                    mansion = updatedMansion.CopyEnvironment();
                    agentCanMove = false;
                    environmentCanUpdate = true;
                }
            }
        }

        public static void UpdateEnvironmentLoop()
        {
            while (true)
            {
                if(environmentCanUpdate)
                {
                    Thread.Sleep(1000);
                    mansion.UpdateEnvironment();
                    mansion.DrawEnvironment();
                    agentCanMove = true;
                    environmentCanUpdate = false;
                }
            }
        }
    }
}
