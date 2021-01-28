using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_td1
{
    class Program
    {
        static void Main(string[] args)
        {
            cEnvironnement mansion = new cEnvironnement();
            mansion.drawEnvironnement();
            cSmartAgent agent = new cSmartAgent(mansion);
         
        }
    }
}
