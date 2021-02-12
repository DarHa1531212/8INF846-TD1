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

        private int actualCost = 0;

        public bool AgentCanMoove
        {
            set { agentCanMove = value; }
        }

        private int cheapestCost = int.MaxValue;
        private List<cAction> bestActionList = new List<cAction>();

        public cSmartAgent(cEnvironment mansion)
        {
            List<cAction> actionsList = new List<cAction>();
            cAction initialSetup = new cAction(Actions.None, 0);
            actionsList.Add(initialSetup);
    
            while (true)
            {
                if (agentCanMove)
                {
                    bestActionList = new List<cAction>();
                    bestActionList.Add(new cAction(Actions.None, 0));
                    cheapestCost = int.MaxValue;

                    List<cEnvironment> forbiddenStates = new List<cEnvironment>();
                    List<cAction> movements = RecursiveDS(actionsList, mansion, 0, forbiddenStates);
                    cAction firstMovementToExecute = movements.ElementAt(1);
                    actualCost = firstMovementToExecute.Cost;

                    //TODO: Act on first movement to execute
                    firstMovementToExecute.DoAction(mansion);

                    agentCanMove = false;
                }
            }
        }

        public cSmartAgent()
        {
            bestActionList.Add(new cAction(Actions.None, 0));
        }


        public List<cAction> RecursiveDS(
            List<cAction> actionList, 
            cEnvironment inEnvironnement, 
            int depth, 
            List<cEnvironment> forbiddenStates
        ) {
            /*int maxDepth = int.MaxValue;
            if (depth == maxDepth)
            {
                return actionList;
            }*/
            
            //test success
            if (inEnvironnement.IsClean())
            {
                actionList.Last().Cost -= 25;
                actionList.Add(new cAction(Actions.None, actionList.Last().Cost));
                return actionList;
            }

            int currentCost = actionList.Last().Cost;

            List<cAction> potentialAction = FindValidActions(currentCost, inEnvironnement);

            /*List<cAction> bestActionList = new List<cAction>();
            bestActionList.Add(new cAction(Actions.None, 0));
            int cheapestCost = int.MaxValue;*/

            foreach (cAction action in potentialAction)
            {
                cEnvironment tempEnv = inEnvironnement.CopyEnvironment(); // Duplication de l'environnement réel actuel
                List<cAction> tempActionList = new List<cAction>(actionList); // Liste d'actions réelles actuelles
                tempActionList.Add(action); // On ajoute le mouvement
                action.DoAction(tempEnv); // On simule l'environnement après mouvement
                
                if (!forbiddenStates.Contains(tempEnv))
                {
                    forbiddenStates.Add(tempEnv);
                    List<cAction> resultList = RecursiveDS(tempActionList, tempEnv, depth + 1, forbiddenStates);
                    
                    // Déterminer le meilleur mouvement
                    if (resultList.Last().Cost < cheapestCost)
                    {
                        cheapestCost = resultList.Last().Cost;
                        bestActionList = tempActionList;
                    }
                }
            }

            return bestActionList;
        }

        // TODO : trouver un moyen de la repasser en private sans casser les tests
        public List<cAction> FindValidActions(int currentCost, cEnvironment inEnvironment)
        {
            int penaltyVacuumJewel = 12;
            int bonusVacuumDust = -9;
            //TODO validate that a given move does not return to a previous position, except for noMouvement


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
