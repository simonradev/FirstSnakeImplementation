namespace Visualizing
{
    using System;
    using Position;
    using System.Collections.Generic;
    using GlobalConstants;
    using HighScoreMenager;
    using Validation;
    using System.Text;

    public static class PrintItems
    {
        public static Random rnd = new Random();
        public static Position foodPosition = new Position(rnd.Next(GlobalConstants.MinimumRowSize, GlobalConstants.MaximumRowSize),
                                                           rnd.Next(GlobalConstants.MinimumColumnSize, GlobalConstants.MaximumColumnlSize));

        public static void PrintTheSnakeOnTheConsole(Queue<Position> snake)
        {
            foreach (Position currPosition in snake)
            {
                Console.SetCursorPosition(currPosition.Col, currPosition.Row);
                Console.Write(GlobalConstants.SnakeBodyPart);
            }
        }

        public static void PrintSnakeFood(Queue<Position> snake, bool generateNewFoodPlace)
        {
            if (generateNewFoodPlace)
            {
                SpawnTheFoodAgain:

                foodPosition = new Position(rnd.Next(GlobalConstants.MinimumRowSize, GlobalConstants.MaximumRowSize),
                                            rnd.Next(GlobalConstants.MinimumColumnSize, GlobalConstants.MaximumColumnlSize));

                bool spotIsValid = PositionCheck.CheckIfFoodSpawnedOnAValidSpot(snake, foodPosition);
                if (!spotIsValid)
                {
                    goto SpawnTheFoodAgain;
                }
            }

            Console.SetCursorPosition(foodPosition.Col, foodPosition.Row);
            Console.Write(GlobalConstants.SnakeFood);
        }

        public static void PrintFinalMessage(string message, Queue<Position> snake)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Current score: {HighScoreMenager.currentScore}");
        }

        public static void ScoreTracker()
        {
            StringBuilder printResult = new StringBuilder();

            string score = $"{HighScoreMenager.currentScore}".PadLeft(5);
            printResult.AppendLine($"{score}|");

            string border = new string('-', GlobalConstants.MaximumColumnlSize);
            printResult.Append(border);

            Console.WriteLine(printResult.ToString());
        }

        public static bool AnotherGameQuestion()
        {
            Console.CursorVisible = true;
            Console.Write(GlobalConstants.DoYouWantToPlayAgainMessage);

            bool willDisplayTryAgainMessage = false;
            TryAgain:

            if (willDisplayTryAgainMessage)
            {
                Console.Write(GlobalConstants.WrongAnswerMessage);
            }

            string answer;
            try
            {
                answer = char.Parse(Console.ReadLine()).ToString().ToLower();
            }
            catch (FormatException)
            {
                willDisplayTryAgainMessage = true;

                goto TryAgain;
            }

            Console.CursorVisible = false;

            if (answer == GlobalConstants.AgreeAnswer)
            {
                return true;
            }
            else if (answer == GlobalConstants.DeclinedAnswer)
            {
                return false;
            }
            else
            {
                willDisplayTryAgainMessage = true;
                goto TryAgain;
            }
        }
    }
}
