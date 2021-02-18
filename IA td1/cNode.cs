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
        int depth;
        public int Depth { get => depth; set => depth = value; }

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

        #region Operators
        public static bool operator ==(cNode node1, cNode node2)
        {
            if (ReferenceEquals(node1, node2))
            {
                return true;
            }
            if (ReferenceEquals(node1, null))
            {
                return false;
            }
            if (ReferenceEquals(node2, null))
            {
                return false;
            }

            return node1.Equals(node2);
        }

        public static bool operator !=(cNode node1, cNode node2)
        {
            return !(node1 == node2);
        }

        public bool Equals(cNode other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Environment.Equals(other.Environment);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as cNode);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Action.GetHashCode();
                hashCode = (hashCode * 397) ^ Environment.GetHashCode();
                hashCode = (hashCode * 397) ^ Depth.GetHashCode();
                hashCode = (hashCode * 397) ^ Parent.GetHashCode();
                hashCode = (hashCode * 397) ^ RealCost.GetHashCode();
                hashCode = (hashCode * 397) ^ EstimatedCost.GetHashCode();
                hashCode = (hashCode * 397) ^ ActionCost.GetHashCode();
                return hashCode;
            }
        }
        #endregion
    }
}
