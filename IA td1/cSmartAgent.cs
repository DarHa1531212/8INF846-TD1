using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{

    public enum Actions
    {
        Right, Left, Up, Down, PickUp, Vacuum, None
    }

    public class cSmartAgent
    {
        #region Constants        
        /// <summary>
        /// The penalty for vacuuming a jewel
        /// </summary>
        const int penaltyVacuumJewel = 12;
        /// <summary>
        /// The bonus for vacuuming dust
        /// </summary>
        const int bonusVacuumDust = -1;
        /// <summary>
        /// The bonus for picking up a jewel
        /// </summary>
        const int bonusPickupJewel = -1;
        #endregion

        #region Attributes        
        /// <summary>
        /// Indicates if the agent can move
        /// </summary>
        private static bool agentCanMove = false;
        /// <summary>
        /// Indicates if the recursive ds solution has already been found
        /// </summary>
        private bool recursiveDSSolutionAlreadyFound = false;

        /// <summary>
        /// The agent's actual cost, given by the environment, as compared to the expected cost determined by the recursiveDS function
        /// </summary>
        private int actualCost = 0;
        /// <summary>
        /// Sets a value indicating whether the agent can moove.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the agent can moove; otherwise, <c>false</c>.
        /// </value>
        public bool AgentCanMoove
        {
            set { agentCanMove = value; }
        }
        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="cSmartAgent"/> class.
        /// </summary>
        /// <param name="mansion">The mansion.</param>
        /// <param name="isInformed">if set to <c>true</c> the exploration will be informed.</param>
        public cSmartAgent(cEnvironment mansion, bool isInformed)
        {
            List<cAction> actionsList = new List<cAction>();
            cAction initialSetup = new cAction(Actions.None, 0);
            actionsList.Add(initialSetup);


            while (true)
            {
                if (agentCanMove)
                {
                    List<cAction> movements = new List<cAction>();

                    List<cEnvironment> forbiddenStates = new List<cEnvironment>();
                    if (isInformed)
                    {
                        //exploration informée
                    }
                    else
                    {
                        recursiveDSSolutionAlreadyFound = false;
                        movements = RecursiveDS(actionsList, mansion, 0, forbiddenStates);

                    }
                    cAction firstMovementToExecute = movements.ElementAt(1);
                    actualCost += firstMovementToExecute.DoAction(mansion);

                    agentCanMove = false;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cSmartAgent"/> class.
        /// </summary>
        public cSmartAgent()
        {
        }

        #endregion

        #region PublicMethods        
        /// <summary>
        /// The A* search algorithme
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <returns>The first action to make in order to reach the agent's goal</returns>
        public Actions AStar(cEnvironment environment)
        {
            List<cNode> openNodesList = new List<cNode>();

            List<cNode> closedNodesList = new List<cNode>();

            cNode rootNode = new cNode(environment);
            rootNode.Parent = null;
            rootNode.EstimatedCost = 0;
            rootNode.RealCost = 0;
            rootNode.ActionCost = 0;
            rootNode.Action = Actions.None;

            if (rootNode.Environment.IsClean())
            {
                return Actions.None;
            }

            openNodesList.Add(rootNode);


            while (openNodesList.Count != 0)
            {

                cNode leastCostingNode = getLeastCostingNode(openNodesList);

                openNodesList.Remove(leastCostingNode);

                List<cNode> successors = generateSuccessors(leastCostingNode);

                foreach (var successor in successors)
                {
                    successor.Parent = leastCostingNode;

                    if (successor.Environment.IsClean())
                    {
                        return retrieveFirstAction(rootNode, successor);
                    }
                    successor.RealCost = leastCostingNode.RealCost + successor.ActionCost;
                    successor.EstimatedCost = successor.RealCost + successor.Environment.ManhattanDistance();

                    List<cNode> lessCostingInstanceOfEnvironmentInOpen = openNodesList.FindAll(
                        delegate (cNode node)
                        {
                            return node.Environment.Equals(successor.Environment)
                                && node.EstimatedCost < successor.EstimatedCost;
                        }
                    );

                    if (lessCostingInstanceOfEnvironmentInOpen.Count != 0)
                    {
                        continue;
                    }

                    List<cNode> lessCostingInstanceOfEnvironmentInClosed = closedNodesList.FindAll(
                        delegate (cNode node)
                        {
                            return node.Environment.Equals(successor.Environment)
                                && node.EstimatedCost < successor.EstimatedCost;
                        }
                    );

                    if (lessCostingInstanceOfEnvironmentInClosed.Count != 0)
                    {
                        continue;
                    }

                    openNodesList.Add(successor);
                }

                closedNodesList.Add(leastCostingNode);
            }

            return Actions.None;
        }

        /// <summary>
        /// Gets the least costing node.
        /// </summary>
        /// <param name="openNodesList">The open nodes list.</param>
        /// <returns>The least costing node.</returns>
        public cNode getLeastCostingNode(List<cNode> openNodesList)
        {
            cNode leastCostingNode = new cNode();
            leastCostingNode.EstimatedCost = int.MaxValue;
            foreach (var node in openNodesList)
            {
                if (node.EstimatedCost < leastCostingNode.EstimatedCost)
                {
                    leastCostingNode = node;
                }
            }
            return leastCostingNode;
        }

        /// <summary>
        /// Generates the successors to a parent node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The list of successor nodes</returns>
        public List<cNode> generateSuccessors(cNode parent)
        {
            List<cNode> successors = new List<cNode>();

            if (parent.Environment.GetAgentLocationStatus() == 'B')
            {
                cNode vacuum = new cNode(
                    parent.Environment,
                    Actions.Vacuum,
                    1 + bonusVacuumDust + penaltyVacuumJewel
                );
                vacuum.Environment.DoAgentAction(vacuum.Action);
                successors.Add(vacuum);
                //TODO : ajouter récompense
                cNode pickup = new cNode(
                    parent.Environment,
                    Actions.PickUp,
                    1 + bonusPickupJewel
                );
                pickup.Environment.DoAgentAction(pickup.Action);
                successors.Add(pickup);
            }

            if (parent.Environment.GetAgentLocationStatus() == 'D')
            {
                cNode vacuum = new cNode(
                    parent.Environment,
                    Actions.Vacuum,
                    1 + bonusVacuumDust
                );
                vacuum.Environment.DoAgentAction(vacuum.Action);
                successors.Add(vacuum);
            }

            if (parent.Environment.GetAgentLocationStatus() == 'J')
            {
                cNode pickup = new cNode(
                    parent.Environment,
                    Actions.PickUp,
                    1 + bonusPickupJewel
                );
                pickup.Environment.DoAgentAction(pickup.Action);
                successors.Add(pickup);
            }


            List<Actions> movementActions = new List<Actions> { Actions.Right, Actions.Left, Actions.Up, Actions.Down };
            foreach (var action in movementActions)
            {
                cNode movement = new cNode(
                    parent.Environment,
                    action,
                    1
                );
                if (!parent.Environment.IsPotentialMoveOutOfBounds(movement.Action))
                {
                    movement.Environment.DoAgentAction(movement.Action);
                    successors.Add(movement);
                }
            }

            return successors;
        }

        /// <summary>
        /// Retrieves the first action.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="goalNode">The goal node.</param>
        /// <returns>The first action</returns>
        public Actions retrieveFirstAction(cNode rootNode, cNode goalNode)
        {
            cNode currentNode = goalNode;
            while (!currentNode.Parent.Environment.Equals(rootNode.Environment))
            {
                currentNode = currentNode.Parent;
            }
            return currentNode.Action;
        }

        /// <summary>
        /// The recurcive depth search function, used for not informed search
        /// </summary>
        /// <param name="actionList">The action list.</param>
        /// <param name="inEnvironnement">The in environnement.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="forbiddenStates">The forbidden states.</param>
        /// <returns>The optimal list of actions</returns>
        public List<cAction> RecursiveDS(List<cAction> actionList,cEnvironment inEnvironnement,int depth,List<cEnvironment> forbiddenStates, int maxDepth = 10)
        {
            //test success
            if (inEnvironnement.IsClean())
            {
                //actionList.Last().Cost -= 25;
                actionList.Add(new cAction(Actions.None, actionList.Last().Cost));
               // recursiveDSSolutionAlreadyFound = true;
                return actionList;
            }

            //todo extract function and unit test**
            if (forbiddenStates.Contains(inEnvironnement))
            {
                return actionList;
            }
           // forbiddenStates.Add(inEnvironnement);

            if (depth > maxDepth /*&& recursiveDSSolutionAlreadyFound*/)
            {
                return actionList;
            }

            int currentCost = actionList.Last().Cost;

            List<cAction> potentialAction = FindValidActions(currentCost, inEnvironnement);

            List<cAction> bestActionList = new List<cAction>();

            int cheapestCost = int.MaxValue;

            foreach (cAction action in potentialAction)
            {
                cEnvironment simulatedActionEnvironment = inEnvironnement.CopyEnvironment(); // Duplication de l'environnement réel actuel             
                action.DoAction(simulatedActionEnvironment); // L'environment après avoir fait l'action, supposons qu'on a aspiré, la poussière ne sera plus là

                List<cAction> simulatedActionList = new List<cAction>(actionList); // Liste d'actions réelles actuelles
                simulatedActionList.Add(action); // On ajoute le mouvement à simuler. 

                List<cEnvironment> alreadyVisitedStates = new List<cEnvironment>(forbiddenStates);

                List<cAction> resultList = new List<cAction>(RecursiveDS(simulatedActionList, simulatedActionEnvironment, depth + 1, alreadyVisitedStates, maxDepth));

                // Déterminer la meilleur action
                if (resultList.Last().Cost < cheapestCost)
                {
                    cheapestCost = resultList.Last().Cost;
                    bestActionList = resultList;
                }


            }

            return bestActionList;
        }

        /// <summary>
        /// Finds all the valid actions.
        /// </summary>
        /// <param name="currentCost">The current cost.</param>
        /// <param name="inEnvironment">The in environment.</param>
        /// <returns>The list of valid actions</returns>
        public List<cAction> FindValidActions(int currentCost, cEnvironment inEnvironment)
        {
            List<cAction> potentialMoves = new List<cAction>();

            if (inEnvironment.GetAgentLocationStatus() == 'B')
            {
                //a given action has a cost of 1, if the agent vacuums on Both, cost points are added as a penalty for vacuuming a jewel
                cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1 + bonusVacuumDust + penaltyVacuumJewel);
                cAction pickupAction = new cAction(Actions.PickUp, currentCost + 1);
                potentialMoves.Add(vacuumAction);
                potentialMoves.Add(pickupAction);
            }

            if (inEnvironment.GetAgentLocationStatus() == 'D')
            {
                cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1 + bonusVacuumDust);
                potentialMoves.Add(vacuumAction);
            }

            if (inEnvironment.GetAgentLocationStatus() == 'J')
            {
                cAction pickupAction = new cAction(Actions.PickUp, currentCost + 1);
                potentialMoves.Add(pickupAction);
            }

            cAction movementRight = new cAction(Actions.Right, currentCost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementRight.LatestAction))
            {
                potentialMoves.Add(movementRight);
            }

            cAction movementLeft = new cAction(Actions.Left, currentCost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementLeft.LatestAction))
            {
                potentialMoves.Add(movementLeft);
            }

            cAction movementDown = new cAction(Actions.Down, currentCost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementDown.LatestAction))
            {
                potentialMoves.Add(movementDown);
            }

            cAction movementUp = new cAction(Actions.Up, currentCost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementUp.LatestAction))
            {
                potentialMoves.Add(movementUp);
            }

            return potentialMoves;
        }
        #endregion

    }
}
