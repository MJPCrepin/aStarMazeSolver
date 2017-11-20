
namespace aStarMazeSolver
{
    // Object used to hold information about each valid grid space
    class Node
    {
        public int x, y;
        public Node parent { get; set; }
        public int f { get; set; } // (g+h)
        public int g { get; set; } // movement cost (from start)
        public int h { get; set; } // heuristic (estimated distance to end)
        public bool isStartPoint, isEndPoint, isPartOfShortestPath;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            parent = null;
            isStartPoint = isEndPoint = isPartOfShortestPath = false;
        }

        public Node(int x, int y, int h)
        {
            this.x = x;
            this.y = y;
            parent = null;
            this.h = h;
            isStartPoint = isEndPoint = isPartOfShortestPath = false;
        }
    }
}
