using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cAction
    {
        #region Attributs

        /// <summary>
        /// The latest action
        /// </summary>
        private Actions latestAction;
        
        /// <summary>
        /// The cost
        /// </summary>
        private int cost;

        /// <summary>
        /// Gets the latest action.
        /// </summary>
        /// <value>
        /// The latest action.
        /// </value>
        public Actions LatestAction { get => latestAction; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public int Cost { get => cost; set => cost = value; }

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="cAction"/> class.
        /// </summary>
        /// <param name="selectedMovement">The selected movement.</param>
        /// <param name="inCost">The in cost.</param>
        public cAction(Actions selectedMovement, int inCost)
        {
            latestAction = selectedMovement;
            cost = inCost;
        }

        #endregion

        #region PublicMethods        
        /// <summary>
        /// Effectue l'action latestAction dans l'environement passé en paramêtre
        /// </summary>
        /// <param name="environment">l'environement.</param>
        /// <returns>La valeur du cout de l'action effectuée</returns>
        public int DoAction(cEnvironment environment)
        {
            return environment.DoAgentAction(latestAction);
        }

        /// <summary>
        /// valide si l'objet est égal à celui passé en paramêtre
        /// </summary>
        /// <param name="other">L'objet passé en paramêtre.</param>
        /// <returns>la valeur de l'égalité</returns>
        protected bool Equals(cAction other)
        {
            return other.LatestAction == latestAction
                   && other.Cost == cost;
        }
        #endregion

        #region Operators        
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
            return Equals((cAction)obj);
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
                int hashCode = cost.GetHashCode();
                hashCode = (hashCode * 397) ^ latestAction.GetHashCode();
                return hashCode;
            }
        }
        #endregion

    }
}
