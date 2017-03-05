namespace GlobalConstants
{
    using System;
    using Position;
    using System.Collections.Generic;

    public static class GlobalConstants
    {
        public static int MinimumColumnSize = 0;
        public static int MaximumColumnlSize = Console.WindowWidth;
        public static int MinimumRowSize = 0;
        public static int MaximumRowSize = Console.WindowHeight;

        public const char SnakeBodyPart = '*';
        public const char SnakeFood = '@';

        public static Queue<Position> InitializeTheSnake()
        {
            Queue<Position> snakeToReturn = new Queue<Position>();
            for (int currCol = 0; currCol < 6; currCol++)
            {
                snakeToReturn.Enqueue(new Position(0, currCol));
            }

            return snakeToReturn;
        }
    }

    public static class AvaliableDirections
    {
        public static Position[] directions = new Position[]
        {
            new Position(0, 1), //right
            new Position(0, -1), //left
            new Position(1, 0), // down
            new Position(-1, 0), //up
        };

        public static Position GetNeededPosition(ConsoleKeyInfo keyInfo)
        {
            int nextDirection = 0;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                nextDirection = 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                nextDirection = 2;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                nextDirection = 3;
            }
            
            return directions[nextDirection];
        }

        public static Position GetNeededPosition(ConsoleKey pressedKey)
        {
            int nextDirection = 0;
            if (pressedKey == ConsoleKey.LeftArrow)
            {
                nextDirection = 1;
            }
            else if (pressedKey == ConsoleKey.DownArrow)
            {
                nextDirection = 2;
            }
            else if (pressedKey == ConsoleKey.UpArrow)
            {
                nextDirection = 3;
            }

            return directions[nextDirection];
        }
    }
}
