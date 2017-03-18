namespace GlobalConstants
{
    using System;
    using Position;
    using System.Collections.Generic;

    public static class GlobalConstants
    {
        public const string HighscoresPath = "..\\..\\HighScores.txt";
        public static readonly string[] InitialPlayers = new string[] { "unknown1: 0", "unknown2: 0", "unknown3: 0" };

        public const string NewHighScoreMessage = "Congradulations you scored a new HIGH SCORE!!!";
        public const string EnterYourNameMessage = "Enter your name (Atleast 3 symbols long!): ";
        public const string NotEnoughLongErrorMessage = "Not enough long!!! Please try again (Atleast 3 symbols long!): ";
        public const string NameAlreadyExistsErrorMessage = "The name already exists!!! Please try again (Atleast 3 symbols long!): ";
        public const string HighScoreTableBorder = "--------------------";
        public const string HighScoreTableTitle = "HIGH SCORE TABLE!!!";

        public const string DoYouWantToPlayAgainMessage = "Do you want to play again ( Y / N ): ";
        public const string WrongAnswerMessage = "Wrong input! Please try again with ( Y / N ): ";
        public const string AgreeAnswer = "y";
        public const string DeclinedAnswer = "n";

        public static int MinimumColumnSize = 0;
        public static int MaximumColumnlSize = Console.WindowWidth;
        public static int MinimumRowSize = 2;
        public static int MaximumRowSize = Console.WindowHeight;

        public const int InitialSnakeLenght = 6;
        public const char SnakeBodyPart = '*';
        public const char SnakeFood = '@';

        public static string SelfBiteExceptionMessage = "You tried to eat yourself... Be ashamed!!!";
        public static string WallHitExceptionMessage = "You hit a wall!!!";

        public static Queue<Position> InitializeTheSnake()
        {
            Queue<Position> snakeToReturn = new Queue<Position>();
            for (int currCol = 0; currCol < InitialSnakeLenght; currCol++)
            {
                snakeToReturn.Enqueue(new Position(2, currCol));
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
