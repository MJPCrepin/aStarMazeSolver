using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    class Pathfinder
    {
        private int mazeWidth, mazeHeight, startX, startY, endX, endY;
        public Node[,] maze;

        public Pathfinder(int mazeWidth, int mazeHeight, int startX, int startY, int endX, int endY)
        {
            this.mazeWidth = mazeWidth;
            this.mazeHeight = mazeHeight;
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
            maze = new Node[mazeHeight, mazeWidth];
        }

        public void SolveMaze()
        {
            
        }

        

    }
}
