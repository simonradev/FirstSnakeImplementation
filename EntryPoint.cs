namespace Snake
{
    using System;
    using System.Collections.Generic;
    using Position;
    using Visualizing;
    using GlobalConstants;
    using System.Threading;

    public class EntryPoint
    {
        public static void Main()
        {
            //creating the first snake in the upper left corner with len of 5
            Queue<Position> snake = new Queue<Position>();
            snake = GlobalConstants.InitializeTheSnake();
            
            //setting the cursor to invisible so the game looks better
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            PrintItems.PrintTheSnakeOnTheConsole(snake);

            Position nextDirection = AvaliableDirections.GetNeededPosition(ConsoleKey.RightArrow);
            bool snakeIsAlive = true;
            while (snakeIsAlive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo currMovement = Console.ReadKey();

                    nextDirection = AvaliableDirections.GetNeededPosition(currMovement);
                }

                Console.Clear();

                snake = SnakeUpdate.UpdateTheSnake(snake, nextDirection);

                PrintItems.PrintTheSnakeOnTheConsole(snake);
                PrintItems.PrintSnakeFood(false);

                Thread.Sleep(ConsoleDelayControl.consoleDelay);
            }
        }
    }
}
