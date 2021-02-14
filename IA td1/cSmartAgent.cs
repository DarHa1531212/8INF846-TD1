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
        private static bool agentCanMove = false;
        private bool recursiveDSSolutionAlreadyFound = false;
        int penaltyVacuumJewel = 12;
        int bonusVacuumDust = -9;

        private int actualCost = 0;

        public bool AgentCanMoove
        {
            set { agentCanMove = value; }
        }

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

        public cSmartAgent()
        {
        }

        public Actions AStar(cEnvironment environment)
        {
            //1.  Initialize the open list
            List<cNode> openNodesList = new List<cNode>();

            /*2.  Initialize the closed list
                put the starting node on the open 
                list (you can leave its f at zero) */
            List<cNode> closedNodesList = new List<cNode>();

            cNode rootNode = new cNode(environment);
            rootNode.Parent = null;
            rootNode.EstimatedCost = 0;
            rootNode.RealCost = 0;
            rootNode.ActionCost = 0;
            rootNode.Action = Actions.None;

            openNodesList.Add(rootNode);

            //3.  while the open list is not empty
            while (openNodesList.Count != 0)
            {
                /*    a) find the node with the least f on 
                       the open list, call it "q" */
                cNode leastCostingNode = getLeastCostingNode(openNodesList);
                //    b) pop q off the open list
                openNodesList.Remove(leastCostingNode);
                /*    c) generate q's X successors and set their 
                       parents to q */
                List<cNode> successors = generateSuccessors(leastCostingNode);
                //    d) for each successor
                foreach (var successor in successors)
                {
                    successor.Parent = leastCostingNode;
                    /*        i) if successor is the goal, stop search
                              successor.g = q.g + distance between 
                                                  successor and q
                              successor.h = distance from goal to 
                              successor (This can be done using many 
                              ways, we will discuss three heuristics- 
                              Manhattan, Diagonal and Euclidean 
                              Heuristics)
                    
                              successor.f = successor.g + successor.h
                    */
                    if (successor.Environment.IsClean())
                    {
                        return retrieveFirstAction(rootNode, successor);
                    }
                    successor.RealCost = leastCostingNode.RealCost + successor.ActionCost;
                    successor.EstimatedCost = successor.RealCost + successor.Environment.ManhattanDistance();
                    /*        ii) if a node with the same position as 
                                successor is in the OPEN list which has a 
                               lower f than successor, skip this successor
                    */
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

                    /*        iii) if a node with the same position as 
                                successor  is in the CLOSED list which has
                                a lower f than successor, skip this successor
                                otherwise, add  the node to the open list */
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
                    //    end (for loop)
                }
                //    e) push q on the closed list
                closedNodesList.Add(leastCostingNode);
                //    end (while loop)
            }

            return Actions.None;
        }

        public cNode getLeastCostingNode(List<cNode> openNodesList)
        {
            cNode leastCostingNode = new cNode();
            leastCostingNode.EstimatedCost = int.MaxValue;
            foreach (var node in openNodesList)
            {
                if(node.EstimatedCost < leastCostingNode.EstimatedCost)
                {
                    leastCostingNode = node;
                }
            }
            return leastCostingNode;
        }

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
                vacuum.Environment.MoveAgent(vacuum.Action);
                successors.Add(vacuum);

                cNode pickup = new cNode(
                    parent.Environment,
                    Actions.PickUp,
                    1
                );
                pickup.Environment.MoveAgent(pickup.Action);
                successors.Add(pickup);
            }

            if (parent.Environment.GetAgentLocationStatus() == 'D')
            {
                cNode vacuum = new cNode(
                    parent.Environment,
                    Actions.Vacuum,
                    1 + bonusVacuumDust
                );
                vacuum.Environment.MoveAgent(vacuum.Action);
                successors.Add(vacuum);
            }

            if (parent.Environment.GetAgentLocationStatus() == 'J')
            {
                cNode pickup = new cNode(
                    parent.Environment,
                    Actions.PickUp,
                    1
                );
                pickup.Environment.MoveAgent(pickup.Action);
                successors.Add(pickup);
            }


            List<Actions> movementActions = new List<Actions>{ Actions.Right, Actions.Left, Actions.Up, Actions.Down };
            foreach (var action in movementActions)
            {
                cNode movement = new cNode(
                    parent.Environment,
                    action,
                    1
                );
                if (!parent.Environment.IsPotentialMoveOutOfBounds(movement.Action))
                {
                    movement.Environment.MoveAgent(movement.Action);
                    successors.Add(movement);
                }
            }

            return successors;
        }

        public Actions retrieveFirstAction (cNode rootNode, cNode goalNode)
        {
            cNode currentNode = goalNode;
            while (!currentNode.Parent.Environment.Equals(rootNode.Environment))
            {
                currentNode = currentNode.Parent;
            }
            return currentNode.Action;
        }

        public List<cAction> RecursiveDS(
        List<cAction> actionList,
        cEnvironment inEnvironnement,
        int depth,
        List<cEnvironment> forbiddenStates
    )
        {
            //test success
            if (inEnvironnement.IsClean())
            {
                actionList.Last().Cost -= 25;
                actionList.Add(new cAction(Actions.None, actionList.Last().Cost));
                recursiveDSSolutionAlreadyFound = true;
                return actionList;
            }

            //todo extract function and unit test
            if (forbiddenStates.Contains(inEnvironnement))
            {
                return actionList;
            }
            forbiddenStates.Add(inEnvironnement);

            if (depth > 10 && recursiveDSSolutionAlreadyFound)
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

                List<cAction> resultList = new List<cAction>(RecursiveDS(simulatedActionList, simulatedActionEnvironment, depth + 1, alreadyVisitedStates));

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

    }
}
