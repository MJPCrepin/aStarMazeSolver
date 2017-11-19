using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    class Pathfinder
    {
        private int mazeWidth, mazeHeight, startX, startY, endX, endY;
        public Node[,] maze;
        private List<Node> open, close;
        private Node startPoint, endPoint;

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

            Test.Hang();

            // if open list empty must return error (no possible path)

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
            if (newTile != null)
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
            finalTile.parent = currentTile;

            // backtrack from finalTile
        }

        private Node TileWithSmallestF()
        {
            // sort open list

            // return first item of sorted list
        }

    }
}
