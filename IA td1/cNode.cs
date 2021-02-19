using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cNode
    {

        #region Attributs        
        /// <summary>
        /// The environment
        /// </summary>
        cEnvironment environment;
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>
        /// The environment.
        /// </value>
        public cEnvironment Environment { get => environment; set => environment = value.CopyEnvironment(); }

        /// <summary>
        /// The parent
        /// </summary>
        cNode parent;
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public cNode Parent { get => parent; set => parent = value; }
        int depth;
        public int Depth { get => depth; set => depth = value; }

        /// <summary>
        /// The real cost
        /// </summary>
        int realCost;
        /// <summary>
        /// Gets or sets the real cost.
        /// </summary>
        /// <value>
        /// The real cost.
        /// </value>
        public int RealCost { get => realCost; set => realCost = value; }

        /// <summary>
        /// The action cost
        /// </summary>
        int actionCost;
        /// <summary>
        /// Gets or sets the action cost.
        /// </summary>
        /// <value>
        /// The action cost.
        /// </value>
        public int ActionCost { get => actionCost; set => actionCost = value; }

        /// <summary>
        /// The action
        /// </summary>
        Actions action;
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Actions Action { get => action; set => action = value; }

        /// <summary>
        /// The estimated cost
        /// </summary>
        int estimatedCost;
        /// <summary>
        /// Gets or sets the estimated cost.
        /// </summary>
        /// <value>
        /// The estimated cost.
        /// </value>
        public int EstimatedCost { get => estimatedCost; set => estimatedCost = value; }

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="cNode"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public cNode(cEnvironment environment)
        {
            this.Environment = environment.CopyEnvironment();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="cNode"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="action">The action.</param>
        /// <param name="actionCost">The action cost.</param>
        public cNode(cEnvironment environment, Actions action, int actionCost)
        {
            this.Environment = environment.CopyEnvironment();
            this.Action = action;
            this.ActionCost = actionCost;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cNode"/> class.
        /// </summary>
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

        /// <summary>
        /// Determines whether the specified instance is equal to this instance.        
        /// /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected bool Equals(cNode other)
        {
            bool areAttributesEqual = true;
            areAttributesEqual = other.Environment.Equals(this.environment) &&
                other.RealCost == this.RealCost &&
                other.ActionCost == this.ActionCost &&
                other.Action == this.Action &&
                other.EstimatedCost == this.EstimatedCost;

            if (areAttributesEqual && this.Parent == null && other.Parent == null)
            {
                return true;
            }
            if (!areAttributesEqual)
            {
                return false;
            }
            if (areAttributesEqual && this.Parent == null)
            {
                return false;
            }
            else
            {
                return this.Parent.Equals(other.Parent);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((cNode)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = RealCost.GetHashCode();
                hashCode = (hashCode * 5) + EstimatedCost.GetHashCode();
                hashCode = (hashCode * 5) + ActionCost.GetHashCode();
                hashCode = (hashCode * 5) + Action.GetHashCode();
                hashCode = (hashCode * 5) + Environment.GetHashCode();

                if (Parent == null)
                {
                    return hashCode;
                }
                else
                {
                    return hashCode + Parent.GetHashCode();
                }
            }
        }

        #endregion

    }
}
