using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    static class Output
    {


        // For testing purposes
        public static void InitialInputTest()
        {
            Console.WriteLine("mazeWidth=" + Input.mazeWidth);
            Console.WriteLine("mazeHeight=" + Input.mazeHeight);
            Console.WriteLine("startX=" + Input.startX);
            Console.WriteLine("startY=" + Input.startY);
            Console.WriteLine("endX=" + Input.endX);
            Console.WriteLine("endY=" + Input.endY);
        }

        // For testing purposes
        public static void MazeParseTest(Node[,] maze)
        {
            Console.WriteLine("Parsed maze:");
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i,j] != null)
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
                        Console.Write(maze[i,j].h+" "); // tests h values
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
