using System;
using System.Collections.Generic;
using System.Text;

namespace aStarMazeSolver
{
    static class Input
    {
        private static int mazeWidth, mazeHeight, startX, startY, endX, endY;

        public static void getInputs()
        {
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

            Console.Read(); // hang


            // Build a MazeParser and pass lines
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
    }
}
