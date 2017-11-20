using System;
using System.Collections.Generic;
using System.Linq;

namespace aStarMazeSolver
{
    // Contains maze with all valid tiles (nodes) and finds shortest maze path
    class Pathfinder
    {
        private int mazeWidth, mazeHeight, startX, startY, endX, endY;
        public Node[,] maze;
        private List<Node> open, close;

        public Pathfinder(int mazeWidth, int mazeHeight, int startX, int startY, int endX, int endY)
        {
            this.mazeWidth = mazeWidth;
            this.mazeHeight = mazeHeight;
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
            maze = new Node[mazeHeight, mazeWidth];
            open = new List<Node>();
            close = new List<Node>();
        }

        public void SolveMaze()
        {
            var startingTile = maze[startX, startY];

            // Recursively navigate through neighbouring tiles
            RecursiveSearch(startingTile);
        }

        private void RecursiveSearch(Node start)
        {
            // put start node in close list
            close.Add(start);

            // find all valid adjacent tiles (+-x, +-y)
            FindAdjacentTiles(start);

            //Test.NextRecursion(open.Count(), close.Count());

            RecursiveSearch(TileWithSmallestF());
        }

        // find all valid adjacent tiles (+-x, +-y) and add to open list
        private void FindAdjacentTiles(Node currentTile)
        {
            // nodes around current tile (no overflow since all mazes have a border wall)
            var west = maze[currentTile.x - 1, currentTile.y];
            var east = maze[currentTile.x + 1, currentTile.y];
            var south = maze[currentTile.x, currentTile.y - 1];
            var north = maze[currentTile.x, currentTile.y + 1];

            // Open adjacent tile to current if valid
            TryAdjacentTile(west, currentTile);
            TryAdjacentTile(east, currentTile);
            TryAdjacentTile(south, currentTile);
            TryAdjacentTile(north, currentTile);
        }

        // Declare current tile parent, do f anf g calculations, add to open list
        private void TryAdjacentTile(Node newTile, Node currentTile)
        {
            // do not add nodes alreay open/closed
            if (newTile != null && !open.Contains(newTile) && !close.Contains(newTile))
            {
                if (newTile.isEndPoint)
                {
                    EndPointReached(newTile, currentTile);
                }
                else
                {
                    newTile.parent = currentTile;
                    newTile.g += currentTile.g;
                    newTile.f = newTile.g + newTile.h;
                    open.Add(newTile);
                }
            }
        }

        private void EndPointReached(Node finalTile, Node currentTile)
        {
            //Test.DeclarePathFound();

            // declare final tile parent
            finalTile.parent = currentTile;

            // backtrack to start, setting path flags
            while (currentTile.isStartPoint != true)
            {
                currentTile.isPartOfShortestPath = true;
                currentTile = currentTile.parent;
            }

            //Test.MazeParse(maze);
            Output.PrintMaze(maze);
            Program.RestartPrompt();
        }

        private Node TileWithSmallestF()
        {
            // if open list empty there is no possible path
            if (open.Count <= 0)
            {
                Console.WriteLine("No path available for this maze. Restart to try another.");
                Program.RestartPrompt();
            }

            // sort open list
            open.OrderBy(node => node.f);

            // pop first item of sorted list
            var first = open.First();
            open.RemoveAt(0);

            return first;
        }

    }
}
