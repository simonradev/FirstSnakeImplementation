namespace Visualizing
{
    public static class ConsoleDelayControl
    {
        public static int consoleDelay = 150;

        public static void FastenUpTheConsoleIfSnakeAteFood()
        {
            if (consoleDelay >= 50)
            {
                consoleDelay -= 3;
            }
        }
    }
}
