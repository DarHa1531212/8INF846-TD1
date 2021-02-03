using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public abstract class cAction
    {
        private int cost;

        List<cAction> forbiddenPositions;


        public int Cost { get => cost; set => cost = value; }

        public abstract void DoAction(cEnvironment environment);
     
        

        public List<cAction> ForbiddenPositions { get => forbiddenPositions; set => forbiddenPositions = value; }

  

    }
}
