namespace Visualizing
{
    public static class ConsoleDelayControl
    {
        public static int consoleDelay = 150;

        public static void FastenUpTheConsoleIfSnakeAteFood()
        {
            consoleDelay -= 3;
        }
    }
}
