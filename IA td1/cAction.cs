using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    class cAction
    {
        private Actions latestAction;
        private int cost;


        public Actions LatestAction { get => latestAction;}
        public int Cost { get => cost; set => cost = value; }

        public cAction(Actions selectedMovement, int inCost)
        {
            latestAction = selectedMovement;
            cost = inCost;
        }

        public void DoAction(cEnvironment environment) {
            environment.MoveAgent(latestAction);
        }
    }
}
