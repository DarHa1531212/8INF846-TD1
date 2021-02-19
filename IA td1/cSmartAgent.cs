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
        const int bonusVacuumDust = 0;
        /// <summary>
        /// The bonus for picking up a jewel
        /// </summary>
        const int bonusPickupJewel = 0;
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
                        //TODO call informed exploration
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
                //return successors;
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
                //return successors;
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
                //return successors;
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
            Console.WriteLine("Action : " + currentNode.Action);
            while (!currentNode.Parent.Environment.Equals(rootNode.Environment))
            {
                currentNode = currentNode.Parent;
                Console.WriteLine("Action : " + currentNode.Action);
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

        public List<cAction> FindValidActions(int currentCost, cEnvironment inEnvironment)
        {
            List<cAction> potentialMoves = new List<cAction>();

            if (inEnvironment.GetAgentLocationStatus() == 'B')
            {
                //a given action has a cost of 1, if the agent vacuums on Both, cost points are added as a penalty for vacuuming a jewel
                //cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1 + bonusVacuumDust + penaltyVacuumJewel);
                cAction pickupAction = new cAction(Actions.PickUp, currentCost + 1);
                //potentialMoves.Add(vacuumAction);
                potentialMoves.Add(pickupAction);
                return potentialMoves;
            }

            if (inEnvironment.GetAgentLocationStatus() == 'D')
            {
                cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1 + bonusVacuumDust);
                potentialMoves.Add(vacuumAction);
                return potentialMoves;
            }

            if (inEnvironment.GetAgentLocationStatus() == 'J')
            {
                cAction pickupAction = new cAction(Actions.PickUp, currentCost + 1);
                potentialMoves.Add(pickupAction);
                return potentialMoves;
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

        //public Actions findBestAction(cEnvironment initialState)
        //{
        //    cNode rootNode = new cNode(initialState);
        //    rootNode.Action = Actions.None;
        //    rootNode.ActionCost = 0;
        //    rootNode.RealCost = int.MaxValue;
        //    rootNode.Parent = null;
        //    rootNode.Depth = 0;

        //    Queue<cNode> outsideBorder = new Queue<cNode>();

        //    return retrieveFirstAction(rootNode, TreeSearch(rootNode, outsideBorder));
        //}

        ///*
        // * Pseudocode from
        // * 8INF846 - Semaine #3 Exploration non informée - Diapo 22
        //*/
        //public cNode TreeSearch(cNode rootNode, Queue<cNode> outsideBorder)
        //{
        //    outsideBorder.Enqueue(rootNode);
        //    cNode bestGoalNode = rootNode;

        //    List<cNode> alreadyVisitedNodes = new List<cNode>();

        //    int cpt = 0;

        //    while (true)
        //    {
        //        if (outsideBorder.Count == 0)
        //        {
        //            return bestGoalNode;
        //        }

        //        cNode node = outsideBorder.Dequeue();
        //        if (node.Environment.IsClean())
        //        {
        //            if (node.RealCost < bestGoalNode.RealCost)
        //            {
        //                bestGoalNode = node;
        //            }
        //        }

        //        /* Reaching depth 13, we return the best path yet even if it's not optimal
        //         * To avoid taking too much time
        //        */
        //        if (node.Depth > 6 && bestGoalNode != rootNode)
        //        {
        //            return bestGoalNode;
        //        }

        //        alreadyVisitedNodes.Add(node);
        //        Console.WriteLine($"{node.Depth} ({cpt++})");
        //        Queue<cNode> successors = Expand(node, alreadyVisitedNodes);
        //        while (successors.Count != 0)
        //        {
        //            outsideBorder.Enqueue(successors.Dequeue());
        //        }
        //        //EnqueueAll(outsideBorder, Expand(node));
        //    }
        //}

        //public void EnqueueAll(Queue<cNode> queue, Queue<cNode> toEnqueue)
        //{
        //    while (toEnqueue.Count != 0)
        //    {
        //        queue.Enqueue(toEnqueue.Dequeue());
        //    }
        //}

        ///*
        // * Code inspired by
        // * 8INF846 - Semaine #3 Exploration non informée - Diapo 22
        //*/
        //public Queue<cNode> Expand(cNode parent, List<cNode> alreadyVisitedNodes)
        //{
        //    Queue<cNode> successors = new Queue<cNode>();
        //    List<Actions> actions = SuccessorFn(parent.Environment);
        //    foreach (var action in actions)
        //    {
        //        cEnvironment sEnvironment = parent.Environment.CopyEnvironment();
        //        int actionCost = sEnvironment.DoAgentAction(action);
        //        cNode s = new cNode(sEnvironment);
        //        s.Parent = parent;
        //        s.Action = action;
        //        s.RealCost = parent.RealCost + actionCost;
        //        s.Depth = parent.Depth + 1;

        //        if (alreadyVisitedNodes.Contains(s))
        //        {
        //            /* If it has been visited sooner, then the subtree having
        //             * s as it's root isn't the best solution and can be skipped
        //             */
        //            continue;
        //        }

        //        successors.Enqueue(s);
        //    }
        //    return successors;
        //}

        //public List<Actions> SuccessorFn(cEnvironment environment)
        //{
        //    List<Actions> potentialActions = new List<Actions>();

        //    if (environment.GetAgentLocationStatus() == 'B')
        //    {
        //        potentialActions.Add(Actions.PickUp);
        //    }

        //    if (environment.GetAgentLocationStatus() == 'D')
        //    {
        //        potentialActions.Add(Actions.Vacuum);
        //    }

        //    if (environment.GetAgentLocationStatus() == 'J')
        //    {
        //        potentialActions.Add(Actions.PickUp);
        //    }

        //    List<Actions> movementActions = new List<Actions> { Actions.Right, Actions.Left, Actions.Up, Actions.Down };
        //    foreach (var action in movementActions)
        //    {
        //        if (!environment.IsPotentialMoveOutOfBounds(action))
        //        {
        //            potentialActions.Add(action);
        //        }
        //    }

        //    return potentialActions;
        //}












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
            int maxDepth = 0;
            while (result.Item2 != RecursiveDLStatus.SUCCESS)
            {
                List<cNode> alreadyVisitedNodes = new List<cNode>();
                result = RecursiveDLS(rootNode, maxDepth, alreadyVisitedNodes);
                maxDepth++;
            }
            return result.Item1;
        }

        /*public Tuple<cNode, RecursiveDLStatus> DepthLimitedSearch(cEnvironment initialState, int maxDepth)
        {
            cNode rootNode = new cNode(initialState);
            rootNode.Action = Actions.None;
            rootNode.ActionCost = 0;
            rootNode.RealCost = int.MaxValue;
            rootNode.Parent = null;
            rootNode.Depth = 0;

            return RecursiveDLS(rootNode, maxDepth);
        }*/

        public enum RecursiveDLStatus { SUCCESS, FAILURE, CUTOFF };

        /*
         * Inspired by pseudocode from
         * 8INF846 - Semaine #3 Exploration non informée - Diapo 33
        */
        public Tuple<cNode, RecursiveDLStatus> RecursiveDLS(cNode currentNode, int maxDepth, List<cNode> alreadyVisitedNodes)
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
    }
}
