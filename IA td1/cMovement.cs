using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_td1
{
    class cMovement
    {
        private int cost;

        private int positionX;
        private int positionY;

        public int PositionY { get => positionY; set => positionY = value; }
        public int PositionX { get => positionX; set => positionX = value; }
        public int Cost { get => cost; set => cost = value; }

        public cMovement(int posX, int posY, int inCost)
        {
            cost = inCost;
            positionX = posX;
            positionY = posY;
        }
  
    }
}
