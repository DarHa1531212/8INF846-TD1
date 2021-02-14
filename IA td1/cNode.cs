using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cNode
    {
        cEnvironment environment;
        public cEnvironment Environment { get => environment; private set => environment = value.CopyEnvironment(); }

        cNode parent;
        public cNode Parent { get => parent; set => parent = value; }

        int realCost;
        public int RealCost { get => realCost; set => realCost = value; }
        int actionCost;
        public int ActionCost { get => actionCost; set => actionCost = value; }
        Actions action;
        public Actions Action { get => action; set => action = value; }
        int estimatedCost;
        public int EstimatedCost { get => estimatedCost; set => estimatedCost = value; }

        #region Ctor
        public cNode(cEnvironment environment)
        {
            this.Environment = environment.CopyEnvironment();
        }
        public cNode(cEnvironment environment, Actions action, int actionCost)
        {
            this.Environment = environment.CopyEnvironment();
            this.Action = action;
            this.ActionCost = actionCost;
        }

        public cNode() { }
        #endregion
    }
}
