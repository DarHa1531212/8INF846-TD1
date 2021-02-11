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

    //TODO clean up diamonds too
    public class cSmartAgent
    {

        private static int locationX;
        private static int locationY;

        private static bool agentCanMove = false;

        private int actualCost = 0;

        public int LocationX
        {
            get { return locationX; }
        }

        public bool AgentCanMoove
        {
            set { agentCanMove = value; }
        }

        public int LocationY
        {
            get { return locationY; }
        }


        public cSmartAgent(cEnvironment mansion)
        {
            List<cAction> actionsList = new List<cAction>();
            cAction initialSetup = new cAction(Actions.None, 0);
            actionsList.Add(initialSetup);
            List<int[]> emptyPosList = new List<int[]>();

            while (true)
            {
                if (agentCanMove)
                {
                    List<cAction> movements = RecursiveDS(actionsList, mansion, 0);
                    cAction firstMovementToExecute = movements.ElementAt(1);
                    actualCost = firstMovementToExecute.Cost;

                    //TODO: Act on first movement to execute
                    firstMovementToExecute.DoAction(mansion);

                    agentCanMove = false;
                }
            }
        }

        public cSmartAgent()
        { }


        private List<cAction> RecursiveDS(List<cAction> positionList, cEnvironment inEnvironnement, int depth) 
        {
            int maxDepth = 8;
            if (depth == maxDepth)
            {
                return positionList;
            }
            
            //test success
            if (!inEnvironnement.HasDust())
            {
                return positionList;
            }
   
            Actions chosenAction;

            int currentCost = positionList.Last().Cost;

            List<cAction> potentialMoves = FindValidActions(currentCost, inEnvironnement);

            List<cAction> bestMoveList = new List<cAction>();
            int cheapestMove = int.MaxValue;

            foreach (cAction move in potentialMoves)
            {
                cEnvironment outEnvironnement = inEnvironnement.CopyEnvironment();
                List<cAction> tempList = positionList;
                tempList.Add(move);
                move.DoAction(outEnvironnement);

                List<cAction> resultList = RecursiveDS(tempList, outEnvironnement, depth +1);
                int cost = resultList.Last().Cost;

                if (cost < cheapestMove)
                {
                    bestMoveList = resultList;
                    cheapestMove = resultList.Last().Cost;
                }
            }
            return bestMoveList;
        }

        // TODO : trouver un moyen de la repasser en private sans casser les tests
        public List<cAction> FindValidActions(int currentCost, cEnvironment inEnvironment)
        {
            int penalty = 5;
            //TODO validate that a given move does not return to a previous position, except for noMouvement


            List<cAction> potentialMoves = new List<cAction>();

            if (inEnvironment.GetAgentLocationStatus() == 'B')
            {
                //a given action has a cost of 1, if the agent vacuums on Both, cost points are added as a penalty for vacuuming a jewel
                cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1 + penalty);
                cAction pickupAction = new cAction(Actions.PickUp, currentCost + 1);
                potentialMoves.Add(vacuumAction);
                potentialMoves.Add(pickupAction);
            }

            if (inEnvironment.GetAgentLocationStatus() == 'D')
            {
                cAction vacuumAction = new cAction(Actions.Vacuum, currentCost + 1);
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
