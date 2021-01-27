using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_td1
{
    class cSmartAgent
    {
        private static int[] location;

        public int[] Location
        {
            get { return location; }
        }

        public cSmartAgent()
        {
            location = new int[2];

            location[0] = 3;
            location[1] = 2;
        }
    }
}
