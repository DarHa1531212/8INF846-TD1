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
        public cEnvironment Environment { get => environment; set => environment = value.CopyEnvironment(); }

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

        protected bool Equals(cNode other)
        {
            bool areAttributesEqual = true;
            areAttributesEqual = other.Environment.Equals(this.environment) &&
                other.RealCost == this.RealCost &&
                other.ActionCost == this.ActionCost &&
                other.Action == this.Action &&
                other.EstimatedCost == this.EstimatedCost;

            if(areAttributesEqual && this.Parent == null && other.Parent == null)
            {
                return true;
            }
            if(!areAttributesEqual)
            {
                return false;
            }
            if(areAttributesEqual && this.Parent == null)
            {
                return false;
            }
            else
            {
                return this.Parent.Equals(other.Parent);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((cNode)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = RealCost.GetHashCode();
                hashCode = (hashCode * 5) + EstimatedCost.GetHashCode();
                hashCode = (hashCode * 5) + ActionCost.GetHashCode();
                hashCode = (hashCode * 5) + Action.GetHashCode();
                hashCode = (hashCode * 5) + Environment.GetHashCode();

                if(Parent == null)
                {
                    return hashCode;
                } else
                {
                    return hashCode + Parent.GetHashCode();
                }
            }
        }

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
