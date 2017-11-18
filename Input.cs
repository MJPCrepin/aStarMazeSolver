﻿using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    static class Input
    {
        private static int mazeWidth, mazeHeight, startX, startY, endX, endY;
        private static Pathfinder pathfinder;

        public static void getInputs()
        {
            // Parse initial information
            getMazeSize();
            getStartPoint();
            getEndPoint();

            // For testing purposes
            //Console.WriteLine("mazeWidth=" + mazeWidth);
            //Console.WriteLine("mazeHeight=" + mazeHeight);
            //Console.WriteLine("startX=" + startX);
            //Console.WriteLine("startY=" + startY);
            //Console.WriteLine("endX=" + endX);
            //Console.WriteLine("endY=" + endY);

            // Build a pathfinder contaning a maze to populate
            pathfinder = new Pathfinder(mazeWidth, mazeHeight, startX, startY, endX, endY);

            // Parse and populate the maze
            getMaze(pathfinder.maze);

            // Have each method pass a completed flag?

            Console.Read(); // hang for testing purposes

        }

        private static void getMazeSize()
        {
            Console.WriteLine("Please enter maze <WIDTH> and <HEIGHT>");

            string[] tokens = Console.ReadLine().Split();
            try
            {
                mazeWidth = int.Parse(tokens[0]);
                mazeHeight = int.Parse(tokens[1]);
            }
            catch
            {
                Console.WriteLine("Invalid input, try again (must be in format <INT> <INT>)");
                getMazeSize();
            }
        }

        private static void getStartPoint()
        {
            Console.WriteLine("Please enter <START_X> and <START_Y>");

            string[] tokens = Console.ReadLine().Split();
            try
            {
                startX = int.Parse(tokens[0]);
                startY = int.Parse(tokens[1]);
            }
            catch
            {
                Console.WriteLine("Invalid input, try again (must be in format <INT> <INT>)");
                getStartPoint();
            }
        }

        private static void getEndPoint()
        {
            Console.WriteLine("Please enter <END_X> and <END_Y>");

            string[] tokens = Console.ReadLine().Split();
            try
            {
                endX = int.Parse(tokens[0]);
                endY = int.Parse(tokens[1]);
            }
            catch
            {
                Console.WriteLine("Invalid input, try again (must be in format <INT> <INT>)");
                getEndPoint();
            }
        }

        private static void getMaze(Node[,] maze)
        {
            Console.WriteLine("Please provide maze");

            try
            {
                // used to find 2d array y

                for (int currentLine = 0; currentLine < mazeHeight; currentLine++)
                {
                    string[] tokens = Console.ReadLine().Split();

                    int currentToken = 0; // used to find 2d array x

                    foreach(string mazeSection in tokens)
                    {
                        var parsedValue = int.Parse(mazeSection);
                        var isNotAWall = (parsedValue.Equals(0));

                        if (isNotAWall) // create a new node
                        {
                            maze[currentLine, currentToken] = 
                                new Node(currentLine, currentToken, calculateH(currentLine, currentToken));
                        }
                        currentToken++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, try again (maze must be square)");
                getMaze(pathfinder.maze);
            }



            // TODO: TEST MAZE PARSING (token++, different sizes, calcH, etc)



        }

        // Returns H value for a node (distance of steps to end point)
        private static int calculateH(int line, int column)
        {
            return Math.Abs(line - endY) + Math.Abs(column - endX);

        }
    }
}
