namespace Snake
{
    using System;
    using System.Collections.Generic;
    using Position;
    using Visualizing;
    using GlobalConstants;
    using System.Threading;
    using Excepions;

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
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo currMovement = Console.ReadKey();

                    nextDirection = AvaliableDirections.GetNeededPosition(currMovement);
                }

                Console.Clear();

                bool snakeAteTheFood;
                try
                {
                    snakeAteTheFood = SnakeUpdate.UpdateTheSnake(snake, nextDirection);
                }
                catch (GameOver goe)
                {
                    PrintItems.PrintMessage(goe.Message);

                    return;
                }

                PrintItems.PrintTheSnakeOnTheConsole(snake);
                PrintItems.PrintSnakeFood(snakeAteTheFood);

                Thread.Sleep(ConsoleDelayControl.consoleDelay);
            }
        }
    }
}
