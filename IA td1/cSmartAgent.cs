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
        Right, Left, Up, Down, PickUp, Vacuum
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
            Console.WriteLine("in Agent");
            List<cAction> actionsList = new List<cAction>();

            while (true)
            {
                if (agentCanMove)
                {
                    List<cAction> movements = RecursiveDS(actionsList, mansion);
                    cAction firstMovementToExecute = movements.First();
                    actualCost = firstMovementToExecute.Cost;

                    //TODO: Act on first movement to execute
                    firstMovementToExecute.DoAction(mansion);
                    moveAgent(mansion);



                    agentCanMove = false;
                }

            }

        }

        public cSmartAgent()
        { }


        private void moveAgent(cEnvironment mansion)
        {

        }
        //non informed search
        private List<cAction> RecursiveDS(List<cAction> positionList, cEnvironment inEnvironnement)
        {
            Actions chosenAction;

            if (!inEnvironnement.HasDust())
            {
                return positionList;
            }

            cEnvironment outEnvironnement = inEnvironnement;
            cAction lastAction = positionList.Last();

            List<cAction> potentialMoves = FindValidActions(lastAction, outEnvironnement);

            List<cAction> bestMove;
            int cheapestMove = 99999;
            foreach (cAction move in potentialMoves /*where move.reussi == true*/)
            {
                List<cAction> tempList = positionList;
                tempList.Add(move);

                List<cAction> resultList = RecursiveDS(tempList,  outEnvironnement);
                int cost = resultList.Last().Cost;

                if (cost < cheapestMove)
                {
                    bestMove = resultList;
                    cheapestMove = resultList.Last().Cost;
                }
            }
            return new List<cAction>();
        }

        private List<cAction> FindValidActions(cAction previousAction, cEnvironment inEnvironment)
        {
            int penalty = 5;
            //TODO validate that a given move does not return to a previous position, except for noMouvement


            List<cAction> potentialMoves = new List<cAction>();

            if (inEnvironment.GetAgentLocationStatus() == 'B')
            {
                //a given action has a cost of 1, if the agent vacuums on Both, cost points are added as a penalty for vacuuming a jewel
                cAction vacuumAction = new cAction(Actions.Vacuum, previousAction.Cost + 1 + penalty);
                cAction pickupAction = new cAction(Actions.PickUp, previousAction.Cost + 1);
                potentialMoves.Add(vacuumAction);
                potentialMoves.Add(pickupAction);
            }

            if (inEnvironment.GetAgentLocationStatus() == 'D')
            {
                cAction vacuumAction = new cAction(Actions.Vacuum, previousAction.Cost + 1);
                potentialMoves.Add(vacuumAction);
            }

            if (inEnvironment.GetAgentLocationStatus() == 'J')
            {
                cAction pickupAction = new cAction(Actions.PickUp, previousAction.Cost + 1);
                potentialMoves.Add(pickupAction);
            }

            cAction movementRight = new cAction(Actions.Right, previousAction.Cost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementRight.LatestAction))
            {
                potentialMoves.Add(movementRight);
            }

            cAction movementLeft = new cAction(Actions.Left, previousAction.Cost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementLeft.LatestAction))
            {
                potentialMoves.Add(movementLeft);
            }

            cAction movementDown = new cAction(Actions.Down, previousAction.Cost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementDown.LatestAction))
            {
                potentialMoves.Add(movementDown);
            }

            cAction movementUp = new cAction(Actions.Up, previousAction.Cost + 1);
            if (!inEnvironment.IsPotentialMoveOutOfBounds(movementUp.LatestAction))
            {
                potentialMoves.Add(movementUp);
            }

            return potentialMoves;
        }

    }
}
