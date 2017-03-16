namespace HighScoreMenager
{
    using System;
    using System.IO;
    using Snake;
    using System.Text;

    public static class HighScoreMenager
    {
        public static int currentScore = EntryPoint.snake.Count - 6;
        private static string[] top3Players = File.ReadAllLines("HighScores.txt");
        private static int[] top3Scores = GetTheTopThreeScores();

        private static int[] GetTheTopThreeScores()
        {
            int[] toReturn = new int[3];

            int index = 0;
            foreach (string player in top3Players)
            {
                string[] playerInfo = player.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                toReturn[index] = int.Parse(playerInfo[1]);

                index++;
            }

            return toReturn;
        }

        public static void PrintCurrentTop3Players()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine();

            foreach (string player in top3Players)
            {
                result.AppendLine(player);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
