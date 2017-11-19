using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    static class Test
    {
        // Used for pausing the program
        public static void Hang()
        {
            Console.WriteLine("Press any key to continue");
            Console.Read();
        }

        // Returns the initial pairs input by user
        public static void InitialInputs
            (int mazeWidth, int mazeHeight, int startX, int startY, int endX, int endY)
        {
            Console.WriteLine("mazeWidth=" + mazeWidth);
            Console.WriteLine("mazeHeight=" + mazeHeight);
            Console.WriteLine("startX=" + startX);
            Console.WriteLine("startY=" + startY);
            Console.WriteLine("endX=" + endX);
            Console.WriteLine("endY=" + endY);

            Hang();
        }

        // Prints the maze nodes with start/end points and heat map (heuristics)
        public static void MazeParse(Node[,] maze)
        {
            Console.WriteLine("Parsed maze:");
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
                            Console.Write(maze[i, j].h + " "); // tests h values
                    }
                    else
                    {
                        Console.Write("# "); // make wall
                    }
                }
                Console.WriteLine(); // continue print on new line
            }

            Hang();
        }
    }
}
