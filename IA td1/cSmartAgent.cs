using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
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


        public cSmartAgent(cEnvironnement mansion)
        {
            locationX = 0;
            locationY = 4;

            cMovement initialPosition = new cMovement(locationX, LocationY, actualCost);
            List<cMovement> positionList = new List<cMovement>();

            positionList.Add(initialPosition);

            while (true)
            {
                if (agentCanMove)
                {
                    List<cMovement> movements = RecursiveDS(mansion.Environnement, positionList);
                    cMovement firstMovementToExecute = movements.First();
                    actualCost = firstMovementToExecute.Cost;
                    
                    //TODO: Act on first movement to execute


                    agentCanMove = false;
                }

            }

        }

        public cSmartAgent()
        { }

        private List<cMovement> RecursiveDS(char[,] inEnvironnement, List<cMovement> positionList)
        {
            bool canMove = true;
            //cutoff occured
            //we have no depth limited, cutoff never occurs due to depth

            //if goal achieved, return node
            if (!HasDust(inEnvironnement))
            {
                return positionList;
            }

            char[,] outEnvironnement = inEnvironnement;
            //get last item from position list
            cMovement temp = positionList.Last();

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
            List<cMovement> potentialMoves = FindValidMoves(temp, canMove);


            List<cMovement> bestMove;
            int cheapestMove = 99999;
            foreach (cMovement move in potentialMoves /*where move.reussi == true*/)
            {
                List<cMovement> tempList = positionList;
                tempList.Add(move);

                List<cMovement> resultList =  RecursiveDS(outEnvironnement, tempList);
                int cost = resultList.Last().Cost;

                if (cost < cheapestMove)
                {
                    bestMove = resultList;
                    cheapestMove = resultList.Last().Cost;
                }
            }



            // RecursiveDS(outEnvironnement)


            //TODO remove this line
            return new List<cMovement>();

        }

        private List<cMovement> FindValidMoves(cMovement position, bool canMove)
        {
            List<cMovement> potentialMoves = new List<cMovement>();

            //TODO validate that a given move does not return to a previous position, except for noMouvement
            if (canMove)
            {
                cMovement movementRight = new cMovement(position.PositionX + 1, position.PositionY, position.Cost + 1);
                if (!IsOutOfBounds(movementRight.PositionX, movementRight.PositionY))
                {
                    potentialMoves.Add(movementRight);
                }

                cMovement movementLeft = new cMovement(position.PositionX - 1, position.PositionY, position.Cost + 1);
                if (!IsOutOfBounds(movementLeft.PositionX, movementLeft.PositionY))
                {
                    potentialMoves.Add(movementLeft);
                }

                cMovement movementBottom = new cMovement(position.PositionX, position.PositionY + 1, position.Cost + 1);
                if (!IsOutOfBounds(movementBottom.PositionX, movementBottom.PositionY))
                {
                    potentialMoves.Add(movementBottom);
                }

                cMovement movementTop = new cMovement(position.PositionX, position.PositionY - 1, position.Cost + 1);
                if (!IsOutOfBounds(movementTop.PositionX, movementTop.PositionY))
                {
                    potentialMoves.Add(movementTop);
                }
            }
            else
            {
                cMovement noMovement = new cMovement(position.PositionX, position.PositionY, position.Cost);
                potentialMoves.Add(noMovement);
            }

            return potentialMoves;
        }

        private bool IsOutOfBounds(int x, int y)
        {
            int bound = 5;
            return (x >= 0) && (x < bound) && (y >= 0) && (y < bound);
        }


        private bool HasDust(char[,] environnement)
        {
            for (int X = 0; X < 5; X++)
            {
                for (int Y = 0; Y < 5; Y++)
                {
                    if (environnement[X, Y] == 'D' || environnement[X, Y] == 'B')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
