using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_TD1
{
    public class cMovement
    {
        private int cost;

        private int positionX;
        private int positionY;

        List<cMovement> forbiddenPositions;

        public int PositionY { get => positionY; set => positionY = value; }
        public int PositionX { get => positionX; set => positionX = value; }
        public int Cost { get => cost; set => cost = value; }

        public List<cMovement> ForbiddenPositions { get => forbiddenPositions; set => forbiddenPositions = value; }

        public cMovement(int posX, int posY, int inCost)
        {
            cost = inCost;
            positionX = posX;
            positionY = posY;
        }
        
        public bool Equals(cMovement other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return positionX == other.positionX && positionY == other.positionY;
        }
    }
}
