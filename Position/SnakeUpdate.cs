﻿namespace Position
{
    using System.Collections.Generic;
    using System.Linq;
    using Validation;
    using Visualizing;

    public static class SnakeUpdate
    {
        public static bool UpdateTheSnake(Queue<Position> snake, Position newHeadPosition)
        {
            Position head = snake.Last();
            Position newHead = new Position(head.Row + newHeadPosition.Row, head.Col + newHeadPosition.Col);

            PositionCheck.CheckIfSnakeCollidesIntoItself(snake, newHead);
            PositionCheck.CheckIfSnakeCollidesIntoAWall(newHead);

            bool snakeAteFood = PositionCheck.CheckIfTheSnakeHadSomeFood(newHead);

            if (!snakeAteFood)
            {
                snake.Dequeue();
            }
            else
            {
                ConsoleDelayControl.FastenUpTheConsoleIfSnakeAteFood();
            }

            snake.Enqueue(newHead);

            return snakeAteFood;
        } 
    }
}
