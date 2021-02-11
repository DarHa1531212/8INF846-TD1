using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cAction
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

        protected bool Equals(cAction other)
        {
            return other.LatestAction == latestAction
                   && other.Cost == cost;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((cAction)obj);
        }
    }
}
