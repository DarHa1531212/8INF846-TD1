using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{

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
   
            locationX = 0;
            locationY = 4;

            cAction initialPosition = new cAction(locationX, LocationY, actualCost);
            List<cAction> positionList = new List<cAction>();

            positionList.Add(initialPosition);

            while (true)
            {
                if (agentCanMove)
                {
                    List<cAction> movements = RecursiveDS(positionList, mansion);
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


        private moveAgent(cEnvironment mansion)
        {
            switch (firstMovementToExecute)
            {
                case "GoLeft":
                    mansion.AgentGoLeft();
                    break;
                case "GoRight": mansion.AgentGoRight();

            }
        }
        //non informed search
        private List<cAction> RecursiveDS(List<cAction> positionList, cEnvironment inEnvironnement)
        {
            bool canMove = true;
            //cutoff occured
            //we have no depth limited, cutoff never occurs due to depth

            //if goal achieved, return node
            if (!inEnvironnement.HasDust())
            {
                return positionList;
            }

            cEnvironment outEnvironnement = inEnvironnement;
            //get last item from position list
            cAction temp = positionList.Last();

            //else if Depth[node] = limit then return cutorr
            //not applicable since we have no cutoff


            if (inEnvironnement[temp.PositionX, temp.PositionY] == 'B')
            {
                //Picked up jewel
                outEnvironnement[temp.PositionX, temp.PositionY] = 'D';
                temp.Cost++;
                canMove = false;
            }
            else if (inEnvironnement[temp.PositionX, temp.PositionY] == 'D')
            {
                outEnvironnement[temp.PositionX, temp.PositionY] = '*';
                temp.Cost++;
                canMove = false;
            }

            //else for each sucessor in EXPAND(Node, problem)
            List<cAction> potentialMoves = FindValidMoves(temp, canMove);


            List<cAction> bestMove;
            int cheapestMove = 99999;
            foreach (cAction move in potentialMoves /*where move.reussi == true*/)
            {
                List<cAction> tempList = positionList;
                tempList.Add(move);

                List<cAction> resultList =  RecursiveDS(outEnvironnement, tempList);
                int cost = resultList.Last().Cost;

                if (cost < cheapestMove)
                {
                    bestMove = resultList;
                    cheapestMove = resultList.Last().Cost;
                }
            }



            // RecursiveDS(outEnvironnement)


            //TODO remove this line
            return new List<cAction>();

        }

        private List<cAction> FindValidMoves(cAction position, bool canMove, cEnvironment inEnvironment)
        {
            List<cAction> potentialMoves = new List<cAction>();

            //TODO validate that a given move does not return to a previous position, except for noMouvement
            if (canMove)
            {
                cAction movementRight = new cAction(position.PositionX + 1, position.PositionY, position.Cost + 1);
                if (!inEnvironment.IsOutOfBounds(movementRight.PositionX, movementRight.PositionY))
                {
                    potentialMoves.Add(movementRight);
                }

                cAction movementLeft = new cAction(position.PositionX - 1, position.PositionY, position.Cost + 1);
                if (!inEnvironment.IsOutOfBounds(movementLeft.PositionX, movementLeft.PositionY))
                {
                    potentialMoves.Add(movementLeft);
                }

                cAction movementBottom = new cAction(position.PositionX, position.PositionY + 1, position.Cost + 1);
                if (!inEnvironment.IsOutOfBounds(movementBottom.PositionX, movementBottom.PositionY))
                {
                    potentialMoves.Add(movementBottom);
                }

                cAction movementTop = new cAction(position.PositionX, position.PositionY - 1, position.Cost + 1);
                if (!inEnvironment.IsOutOfBounds(movementTop.PositionX, movementTop.PositionY))
                {
                    potentialMoves.Add(movementTop);
                }
            }
            else
            {
                cAction noMovement = new cAction(position.PositionX, position.PositionY, position.Cost);
                potentialMoves.Add(noMovement);
            }

            return potentialMoves;
        }




       

    }
}
