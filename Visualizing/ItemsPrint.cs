namespace Visualizing
{
    using System;
    using Position;
    using System.Collections.Generic;
    using GlobalConstants;
    using Validation;

    public static class PrintItems
    {
        public static Random rnd = new Random();
        public static Position foodPosition = new Position(rnd.Next(0, Console.WindowHeight), rnd.Next(0, Console.WindowWidth));

        public static void PrintTheSnakeOnTheConsole(Queue<Position> snake)
        {
            foreach (Position currPosition in snake)
            {
                PositionCheck.CheckIfSnakeCollidesIntoAWall(currPosition);

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
    }
}
