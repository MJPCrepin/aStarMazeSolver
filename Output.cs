using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    static class Output
    {

        // Prints the maze nodes with start/end points and heat map (heuristics)
        public static void PrintMaze(Node[,] maze)
        {
            Console.WriteLine("Solved maze: ");

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] != null)
                    {
                        if (maze[i, j].isStartPoint)
                        {
                            Console.Write("S "); // test start point parse
                        }
                        else if (maze[i, j].isEndPoint)
                        {
                            Console.Write("E "); // test end point parse
                        }
                        else if (maze[i, j].isPartOfShortestPath)
                        {
                            Console.Write("X "); // test path parse
                        }
                        else
                            Console.Write("  "); // tests h values
                    }
                    else
                    {
                        Console.Write("# "); // make wall
                    }
                }
                Console.WriteLine(); // continue print on new line
            }
        }

    }
}
