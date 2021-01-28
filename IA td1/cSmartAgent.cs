using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_td1
{
    class cSmartAgent
    {
        private static int locationX;
        private static int locationY;

        private static bool agentCanMove = false;


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

            cMovement initialPosition = new cMovement(locationX, LocationY, 0);
            List<cMovement> positionList = new List<cMovement>();

            positionList.Add(initialPosition);
            // Thread.Sleep(1500);
            while (true)
            {
                if (agentCanMove)
                {
                    RecursiveDS(mansion.Environnement, positionList);
                }

            }

        }

        private List<cMovement> RecursiveDS(char[,] inEnvironnement, List<cMovement> positionList)
        {
            //if there's no more dust
            if (!HasDust(inEnvironnement))
            {
                return positionList;
            }

            char[,] outEnvironnement = inEnvironnement;
            //get last item from position list
            cMovement temp = positionList.Last();

            if (inEnvironnement[temp.PositionX, temp.PositionY] == 'B')
            {
                outEnvironnement[temp.PositionX, temp.PositionY] = 'D';
                temp.Cost++;
            }
            else if (inEnvironnement[temp.PositionX, temp.PositionY] == 'J')
            {
                outEnvironnement[temp.PositionX, temp.PositionY] = '*';
                temp.Cost++;
            }
            else if (inEnvironnement[temp.PositionX, temp.PositionY] == 'D')
            {
                outEnvironnement[temp.PositionX, temp.PositionY] = '*';
                temp.Cost++;
            }

            //list potential moves
            List<cMovement> potentialMoves = FindValidMoves(temp);

            cMovement bestMove;
            int cheapestMove = 99999;
            foreach (cMovement move in potentialMoves)
            {
                if (move.Cost < cheapestMove)
                {
                    bestMove = move;
                    cheapestMove = move.Cost;
                }
            }

            return 

           / RecursiveDS(outEnvironnement)


            //TODO remove this line
            return new List<cMovement>();

            //TODO pseudo code page 33

            //TODO valider la conformité du code avec celui vu en classe

            /*
             if but atteint, 
                return

            else pondérer déplacement
                    int meilleure déplacement = -999;
                    meilleur lst<int[,]>
                forceach déplacement possible, 
                     //x +1
                     //x -1
                     //y +1
                     //y -1
                     //y = y
                    noter la qualité du déplacement
                        if cost > best cost
                            meilleur = déplacement
             */

        }

        private List<cMovement> FindValidMoves(cMovement position) {
            //potential moves
            List<cMovement> potentialMoves = new List<cMovement>;

            //TODO validate that a given move does not return to a previous position, except for noMouvement

            cMovement movementRight = new cMovement(position.PositionX + 1, position.PositionY, position.Cost + 1);
            if(!IsOutOfBounds(movementRight.PositionX, movementRight.PositionY)) {
                potentialMoves.Add(movementRight);
            }

            cMovement movementLeft = new cMovement(position.PositionX - 1, position.PositionY, position.Cost + 1);
            if(!IsOutOfBounds(movementLeft.PositionX, movementLeft.PositionY)) {
                potentialMoves.Add(movementLeft);
            }
            
            cMovement movementBottom = new cMovement(position.PositionX, position.PositionY + 1, position.Cost + 1);
            if(!IsOutOfBounds(movementBottom.PositionX, movementBottom.PositionY)) {
                potentialMoves.Add(movementBottom);
            }
            
            cMovement movementTop = new cMovement(position.PositionX, position.PositionY - 1, position.Cost + 1);
            if(!IsOutOfBounds(movementTop.PositionX, movementTop.PositionY)) {
                potentialMoves.Add(movementTop);
            }
            
            cMovement noMovement = new cMovement(position.PositionX, position.PositionY, position.Cost + 1);
            potentialMoves.Add(noMovement);

            return potentialMoves;
        }

        private bool IsOutOfBounds(int x, int y) {
            int bound = 5;
            return (x >= 0) && (x < bound) && (y >= 0) && (y < bound)
        }
            

        private bool HasDust(char[,] environnement)
        {

            bool found = false;

            for (int X = 0; X < 5; X++) {
                for (int Y = 0; Y < 5; Y++)
                {
                    if (environnement[X, Y] == 'D' || environnement[X, Y] == 'B')
                    {
                        found = true;
                        break;
                    }
                }
            }
            return true;
        }

        //s'il y a un diamant ici, ramasser

        //s'il y a de la poussière, aspirer

        //déplacer

        //on ajoute la case précédente dans la liste des cases traitées

        //rester

        //x +1

        //x -1

        //y +1

        //y -1

    }
}
