using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    // Object used to hold information about each valid grid space
    class Node
    {
        private int x, y;
        Node parent { get; set; }
        private int f { get; set; } // (g+h)
        private int g { get; set; } // movement cost (from start)
        private int h { get; set; } // heuristic (estimated distance to end)

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            parent = null;
        }

        public Node(int x, int y, int h)
        {
            this.x = x;
            this.y = y;
            parent = null;
            this.h = h;
        }
    }
}
