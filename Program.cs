using System;

namespace aStarMazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A simple C# maze solver for grid mazes using the A* algorithm, " +
                "restricted to vertical/horizontal movement, " +
                "and using Manhattan heuristics. \n");

            Start();
        }

        private static void Start()
        {
            Input input = new Input();

            // Get user inputs and generate the maze and pathfinder
            input.getInputs();

            // Solve the maze using pathfinder
            input.pathfinder.SolveMaze();

        }

        public static void RestartPrompt()
        {
            Console.WriteLine("Restart? (y/n)");
            var input = Console.Read();

            switch (input)
            {
                case 'y': Start(); break;
                case 'n': Environment.Exit(0); break;
                default: RestartPrompt(); break;
            }
        }
    }
}