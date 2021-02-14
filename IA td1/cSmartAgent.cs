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

        //public List<cAction> AStar()
        //{
        //    //1.  Initialize the open list
        //    List<cEnvironment> openNodesList = new List<cEnvironment>();
        //    /*2.  Initialize the closed list
        //        put the starting node on the open 
        //        list (you can leave its f at zero) */
        //    List<cEnvironment> closedNodesList = new List<cEnvironment>();
        //    //3.  while the open list is not empty
        //    while (openNodesList.Count != 0)
        //    {
        //        /*    a) find the node with the least f on 
        //               the open list, call it "q" */
        //        cEnvironment leastCosting = getLeastCosting();
        //        //    b) pop q off the open list
        //        openNodesList.Remove(leastCosting);
        //        /*    c) generate q's 8 successors and set their 
        //               parents to q */
        //        List<cEnvironment> successors = leastCosting.generateSuccessors();
        //        //    d) for each successor
        //        foreach (cEnvironment successor in successors)
        //        {
        //            successor.parent = leastCosting;
        //            /*        i) if successor is the goal, stop search
        //                      successor.g = q.g + distance between 
        //                                          successor and q
        //                      successor.h = distance from goal to 
        //                      successor (This can be done using many 
        //                      ways, we will discuss three heuristics- 
        //                      Manhattan, Diagonal and Euclidean 
        //                      Heuristics)
                    
        //                      successor.f = successor.g + successor.h
        //            */
        //            if (successor.IsClean()) {
        //                return new List<cAction>(); //return list des actions pour arriver jusqu'à ce successeur
        //            }
        //            successor.f = (leastCosting.g + leastCosting.distanceTo(successor))
        //                + (successor.distanceTo(goal));
        //            /*        ii) if a node with the same position as 
        //                        successor is in the OPEN list which has a 
        //                       lower f than successor, skip this successor
        //            */
        //            List<cEnvironment> alreadyExistingSuccessorsInOpen = openNodesList.FindAll(
        //                delegate(cEnvironment env)
        //                {
        //                    return env.Equals(successor) && env.f < successor.f;
        //                }
        //            );
        //            if (alreadyExistingSuccessorsInOpen.Count == 0)
        //            {
        //                /*        iii) if a node with the same position as 
        //                            successor  is in the CLOSED list which has
        //                            a lower f than successor, skip this successor
        //                            otherwise, add  the node to the open list */
        //                List<cEnvironment> alreadyExistingSuccessorsInClosed = closedNodesList.FindAll(
        //                    delegate (cEnvironment env)
        //                    {
        //                        return env.Equals(successor) && env.f < successor.f;
        //                    }
        //                );
        //                if (alreadyExistingSuccessorsInClosed.Count == 0)
        //                {
        //                    openNodesList.Add(successor);
        //                }
        //            }
        //             //    end (for loop)
        //        }
        //        //    e) push q on the closed list
        //        closedNodesList.Add(leastCosting);
        //        //    end (while loop)
        //    }


            /*// A * Search Algorithm
            1.  Initialize the open list
            2.  Initialize the closed list
                put the starting node on the open 
                list (you can leave its f at zero)

            3.  while the open list is not empty
                a) find the node with the least f on 
                   the open list, call it "q"

                b) pop q off the open list

                c) generate q's 8 successors and set their 
                   parents to q

                d) for each successor
                    i) if successor is the goal, stop search
                      successor.g = q.g + distance between 
                                          successor and q
                      successor.h = distance from goal to 
                      successor (This can be done using many 
                      ways, we will discuss three heuristics- 
                      Manhattan, Diagonal and Euclidean 
                      Heuristics)

                      successor.f = successor.g + successor.h

                    ii) if a node with the same position as 
                        successor is in the OPEN list which has a 
                       lower f than successor, skip this successor

                    iii) if a node with the same position as 
                        successor  is in the CLOSED list which has
                        a lower f than successor, skip this successor
                        otherwise, add  the node to the open list
                 end (for loop)

                e) push q on the closed list
                end (while loop)*/
        // }


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

        // TODO : trouver un moyen de la repasser en private sans casser les tests
        public List<cAction> FindValidActions(int currentCost, cEnvironment inEnvironment)
        {
            int penaltyVacuumJewel = 12;
            int bonusVacuumDust = -9;


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
