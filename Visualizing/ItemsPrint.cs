namespace Visualizing
{
    using System;
    using Position;
    using System.Collections.Generic;
    using GlobalConstants;

    public static class PrintItems
    {
        public static Random rnd = new Random();
        public static Position foodPosition = new Position(rnd.Next(0, Console.WindowHeight), rnd.Next(0, Console.WindowWidth));

        public static void PrintTheSnakeOnTheConsole(Queue<Position> snake)
        {
            foreach (Position currPosition in snake)
            {
                Console.SetCursorPosition(currPosition.Col, currPosition.Row);
                Console.Write(GlobalConstants.SnakeBodyPart);
            }
        }

        public static void PrintSnakeFood(bool generateNewFoodPlace)
        {
            if (generateNewFoodPlace)
            {
                foodPosition = new Position(rnd.Next(0, Console.WindowHeight), rnd.Next(0, Console.WindowWidth));
            }

            Console.SetCursorPosition(foodPosition.Col, foodPosition.Row);
            Console.Write(GlobalConstants.SnakeFood);
        }

        public static void PrintFinalMessage(string message, Queue<Position> snake)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Current score: {snake.Count - 6}");
        }
    }
}
