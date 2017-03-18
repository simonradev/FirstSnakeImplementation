namespace HighScoreMenager
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using GlobalConstants;
    using Position;

    public static class HighScoreMenager
    {
        public static int currentScore;
        public static string[] top3Players = ReadHighscores();
        private static Dictionary<string, int> top3Scores = GetTheTopThreeScores();

        public static void UpdateTheCurrentScore(Queue<Position> snake)
        {
            currentScore = snake.Count - GlobalConstants.InitialSnakeLenght;
        }

        public static string[] ReadHighscores()
        {
            if (!File.Exists(GlobalConstants.HighscoresPath))
            {
                File.WriteAllLines(GlobalConstants.HighscoresPath, GlobalConstants.InitialPlayers);
            }

            return File.ReadAllLines(GlobalConstants.HighscoresPath);
        }


        private static Dictionary<string, int> GetTheTopThreeScores()
        {
            Dictionary<string, int> toReturn = new Dictionary<string, int>();

            foreach (string player in top3Players)
            {
                string[] playerInfo = player.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                toReturn.Add(playerInfo[0], int.Parse(playerInfo[1]));
            }

            return toReturn;
        }

        public static void PrintCurrentTop3Players(bool tableIsUpdated)
        {
            if (tableIsUpdated)
            {
                top3Players = ReadHighscores();
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine();
            result.AppendLine(GlobalConstants.HighScoreTableBorder);
            result.AppendLine(GlobalConstants.HighScoreTableTitle);
            result.AppendLine(GlobalConstants.HighScoreTableBorder);

            foreach (string player in top3Players)
            {
                result.AppendLine(player);
            }

            result.AppendLine(GlobalConstants.HighScoreTableBorder);

            Console.WriteLine(result.ToString());
        }

        public static void CheckIfThereIsANewHighscoreAndUpdate()
        {
            bool thereIsNewHighscore = false;

            foreach (KeyValuePair<string, int> playerScore in top3Scores)
            {
                if (playerScore.Value < currentScore)
                {
                    thereIsNewHighscore = true;

                    break;
                }
            }

            if (thereIsNewHighscore)
            {
                Console.CursorVisible = true;

                StringBuilder result = new StringBuilder();
                result.AppendLine(GlobalConstants.NewHighScoreMessage);
                result.Append(GlobalConstants.EnterYourNameMessage);

                Console.Write(result.ToString());

                bool hasEnteredWrongName = false;
                bool nameExists = false;

                EnterTheNameAgain:
                if (hasEnteredWrongName)
                {
                    Console.Write(GlobalConstants.NotEnoughLongErrorMessage);

                    hasEnteredWrongName = false;
                }
                else if (nameExists)
                {
                    Console.Write(GlobalConstants.NameAlreadyExistsErrorMessage);

                    nameExists = false;
                }

                string name = Console.ReadLine();

                nameExists = CheckIfTheNameExits(name);

                if (name.Length < 3)
                {
                    hasEnteredWrongName = true;

                    goto EnterTheNameAgain;
                }
                else if (nameExists)
                {
                    nameExists = true;

                    goto EnterTheNameAgain;
                }

                Console.CursorVisible = false;

                UpdateTheHighscoreTable(name);

                PrintCurrentTop3Players(true);
            }
            else
            {
                PrintCurrentTop3Players(false);
            }
        }

        private static bool CheckIfTheNameExits(string name)
        {
            bool toReturn = false;

            foreach (KeyValuePair<string, int> player in top3Scores)
            {
                if (player.Key == name)
                {
                    toReturn = true;

                    break;
                }
            }

            return toReturn;
        }

        private static void UpdateTheHighscoreTable(string newName)
        {
            top3Scores.Add(newName, currentScore);

            top3Scores = top3Scores.OrderByDescending(s => s.Value).Take(3).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            string[] toWriteInText = new string[3];
            int index = 0;
            foreach (KeyValuePair<string, int> playerScore in top3Scores)
            {
                toWriteInText[index] = $"{playerScore.Key}: {playerScore.Value}";

                index++;
            }

            File.WriteAllLines(GlobalConstants.HighscoresPath, toWriteInText);
        }
    }
}
