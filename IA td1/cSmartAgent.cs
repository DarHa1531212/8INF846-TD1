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
        const ushort _penaltyVacuumJewel = 12;
        /// <summary>
        /// The bonus for vacuuming dust
        /// </summary>
        const ushort _bonusVacuumDust = 1;
        /// <summary>
        /// The bonus for picking up a jewel
        /// </summary>
        const ushort _bonusPickupJewel = 1;
        /// <summary>
        /// Limit for the recursive depth-first limited search
        /// </summary>
        const ushort _maxDepthSearch = 8;

        #endregion

        #region Attributes
        /// <summary>
        /// Indicates if the agent uses informed or non informed search algorithms
        /// </summary>
        private bool isInformed = false;

        /// <summary>
        /// The agent's actual cost, given by the environment, as compared to the expected cost determined by the recursiveDS function
        /// </summary>
        private int actualCost = 0;

        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="cSmartAgent"/> class.
        /// </summary>
        /// <param name="mansion">The mansion.</param>
        /// <param name="isInformed">if set to <c>true</c> the exploration will be informed.</param>
        public cSmartAgent(bool isInformed)
        {
            this.isInformed = isInformed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cSmartAgent"/> class.
        /// </summary>
        public cSmartAgent()
        { }

        #endregion

        #region Public Methods

        public cEnvironment lifeCycle(cEnvironment mansion)
        {
            cNode rootNode = new cNode(mansion, Actions.None, 0);
            rootNode.Parent = null;
            rootNode.RealCost = 0;
            rootNode.Depth = 0;
            
            Actions actionToExecute = Actions.None;

            if (isInformed)
            {
                actionToExecute = AStar(mansion);
            }
            else
            {
                actionToExecute = retrieveFirstAction(rootNode, IterativeDeepening(rootNode));
            }
            actualCost += mansion.DoAgentAction(actionToExecute);
            
            return mansion;
        }

        #region Informed

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

                if (leastCostingNode.Environment.IsClean())
                {
                    return retrieveFirstAction(rootNode, leastCostingNode);
                }

                List<cNode> successors = generateSuccessors(leastCostingNode);

                foreach (var successor in successors)
                {
                    successor.Parent = leastCostingNode;
                    successor.RealCost = leastCostingNode.RealCost + successor.ActionCost;
                    successor.EstimatedCost = successor.RealCost + successor.Environment.Heuristic();

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

            if (parent.Environment.GetAgentLocationStatus() == 'D' || parent.Environment.GetAgentLocationStatus() == 'B')
            {
                cNode vacuum = new cNode(parent.Environment);
                vacuum.Action = Actions.Vacuum;
                vacuum.ActionCost = vacuum.Environment.DoAgentAction(vacuum.Action);
                successors.Add(vacuum);
                //return successors;
            }

            if (parent.Environment.GetAgentLocationStatus() == 'J' || parent.Environment.GetAgentLocationStatus() == 'B')
            {
                cNode pickup = new cNode(parent.Environment);
                pickup.Action = Actions.PickUp;
                pickup.ActionCost = pickup.Environment.DoAgentAction(pickup.Action);
                successors.Add(pickup);
                //return successors;
            }


            List<Actions> movementActions = new List<Actions> { Actions.Right, Actions.Left, Actions.Up, Actions.Down };
            foreach (var action in movementActions)
            {
                cNode movement = new cNode(parent.Environment);
                movement.Action = action;
                if (!parent.Environment.IsPotentialMoveOutOfBounds(movement.Action))
                {
                    movement.ActionCost = movement.Environment.DoAgentAction(movement.Action);
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
            while (currentNode.Parent != null && !currentNode.Parent.Environment.Equals(rootNode.Environment))
            {
                currentNode = currentNode.Parent;
            }
            return currentNode.Action;
        }

        public List<Actions> retrieveActionList(cNode rootNode, cNode goalNode)
        {
            List<Actions> actionList = new List<Actions>();
            cNode currentNode = goalNode;
            while (currentNode.Parent != null && !currentNode.Parent.Environment.Equals(rootNode.Environment))
            {
                actionList.Add(currentNode.Action);
                currentNode = currentNode.Parent;
            }
            actionList.Add(currentNode.Action);
            actionList.Reverse();
            return actionList;
        }
        
        #endregion

        #region Non Informed

        public Actions FindBestAction(cEnvironment initialState)
        {
            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            return retrieveFirstAction(rootNode, IterativeDeepening(rootNode));
        }

        // TODO : si FAILURE est retourné, que faire ?
        public cNode IterativeDeepening(cNode rootNode)
        {
            Tuple<cNode, RecursiveDLStatus> result =
                new Tuple<cNode, RecursiveDLStatus>(null, RecursiveDLStatus.FAILURE);
            ushort maxDepth = 0;
            while (result.Item2 != RecursiveDLStatus.SUCCESS)
            {
                List<cNode> alreadyVisitedNodes = new List<cNode>();
                result = RecursiveDLS(rootNode, maxDepth, alreadyVisitedNodes);
                maxDepth++;
            }
            return result.Item1;
        }
        
        public enum RecursiveDLStatus { SUCCESS, FAILURE, CUTOFF };

        /*
         * Inspired by pseudocode from
         * 8INF846 - Semaine #3 Exploration non informée - Diapo 33
        */
        public Tuple<cNode, RecursiveDLStatus> RecursiveDLS(cNode currentNode, ushort maxDepth, List<cNode> alreadyVisitedNodes)
        {
            bool cutoffOccured = false;

            if (currentNode.Environment.IsClean())
            {
                return new Tuple<cNode, RecursiveDLStatus>(
                    currentNode,
                    RecursiveDLStatus.SUCCESS
                );
            }

            if (currentNode.Depth > maxDepth || alreadyVisitedNodes.Contains(currentNode))
            {
                return new Tuple<cNode, RecursiveDLStatus>(
                    null,
                    RecursiveDLStatus.CUTOFF
                );
            }

            List<cNode> alreadyVisitedNodesExtended = new List<cNode>(alreadyVisitedNodes);
            alreadyVisitedNodesExtended.Add(currentNode);

            List<cNode> successors = Expand(currentNode);

            foreach (var successor in successors)
            {
                try
                {
                    Tuple<cNode, RecursiveDLStatus> result = RecursiveDLS(successor, maxDepth, alreadyVisitedNodesExtended);

                    if (result.Item2 == RecursiveDLStatus.CUTOFF)
                    {
                        cutoffOccured = true;
                    }

                    if (result.Item2 == RecursiveDLStatus.SUCCESS)
                    {
                        return result;
                    }

                    if (result.Item2 == RecursiveDLStatus.FAILURE)
                    {
                        return new Tuple<cNode, RecursiveDLStatus>(
                            null,
                            RecursiveDLStatus.FAILURE
                        );
                    }
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Message);
                    return new Tuple<cNode, RecursiveDLStatus>(
                        null,
                        RecursiveDLStatus.FAILURE
                    );
                }
            }

            if (cutoffOccured)
            {
                return new Tuple<cNode, RecursiveDLStatus>(
                    null,
                    RecursiveDLStatus.CUTOFF
                );
            }

            return new Tuple<cNode, RecursiveDLStatus>(
                null,
                RecursiveDLStatus.FAILURE
            );
        }

        /*
         * Inspired by pseudocode from
         * 8INF846 - Semaine #3 Exploration non informée - Diapo 22
        */
        public List<cNode> Expand(cNode parent)
        {
            List<cNode> successors = new List<cNode>();
            List<Actions> actions = SuccessorFn(parent.Environment);

            foreach (var action in actions)
            {
                cEnvironment sEnvironment = parent.Environment.CopyEnvironment();
                int actionCost = sEnvironment.DoAgentAction(action);
                cNode s = new cNode(sEnvironment);
                s.Parent = parent;
                s.Action = action;
                s.ActionCost = actionCost;
                s.RealCost = parent.RealCost + actionCost;
                s.Depth = parent.Depth + 1;
                successors.Add(s);
            }
            return successors;
        }

        /* TODO : Se mettre d'accord sur la génération des enfants */
        public List<Actions> SuccessorFn(cEnvironment environment)
        {
            List<Actions> potentialActions = new List<Actions>();

            if (environment.GetAgentLocationStatus() == 'B')
            {
                potentialActions.Add(Actions.PickUp);
                return potentialActions;
            }

            if (environment.GetAgentLocationStatus() == 'D')
            {
                potentialActions.Add(Actions.Vacuum);
                return potentialActions;
            }

            if (environment.GetAgentLocationStatus() == 'J')
            {
                potentialActions.Add(Actions.PickUp);
                return potentialActions;
            }

            List<Actions> movementActions = new List<Actions> { Actions.Right, Actions.Left, Actions.Up, Actions.Down };
            foreach (var action in movementActions)
            {
                if (!environment.IsPotentialMoveOutOfBounds(action))
                {
                    potentialActions.Add(action);
                }
            }

            return potentialActions;
        }

        #endregion

        #endregion
    }
}
