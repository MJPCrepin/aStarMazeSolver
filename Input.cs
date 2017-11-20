using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    // Instantiated input class for easier restart. Gathers all user inputs and produces Pathfinder
    class Input
    {
        private int mazeWidth, mazeHeight, startX, startY, endX, endY;
        public Pathfinder pathfinder;

        public void getInputs()
        {
            // Parse initial information
            GetMazeSize();
            GetStartPoint();
            GetEndPoint();

            //Test.InitialInputs(mazeWidth, mazeHeight, startX, startY, endX, endY); // test inputs

            // Build a pathfinder contaning a maze to populate
            pathfinder = new Pathfinder(mazeWidth, mazeHeight, startX, startY, endX, endY);

            // Parse maze input and populate the maze
            GetMaze(pathfinder.maze);

            //Test.MazeParse(pathfinder.maze); // test maze parse with heuristics
        }

        public void SolveMaze()
        {
            pathfinder.SolveMaze();
        }

        private void GetMazeSize()
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
                GetMazeSize();
            }
        }

        private void GetStartPoint()
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
                GetStartPoint();
            }
        }

        private void GetEndPoint()
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
                GetEndPoint();
            }
        }

        private void GetMaze(Node[,] maze)
        {
            Console.WriteLine("Please provide maze");

            try
            {
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
                Console.WriteLine("Invalid input, try again (maze must be of provided size)");
                GetMaze(pathfinder.maze);
            }

            setStartAndEndPoint();
        }

        // Give nodes flags for easier output
        private void setStartAndEndPoint()
        {
            pathfinder.maze[startY, startX].isStartPoint = true;
            pathfinder.maze[endY, endX].isEndPoint = true;
        }

        // Returns H value for a node (distance of steps to end point)
        private int calculateH(int line, int column)
        {
            return Math.Abs(line - endY) + Math.Abs(column - endX);
        }
    }
}
