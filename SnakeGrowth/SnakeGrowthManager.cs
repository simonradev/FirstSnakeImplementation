namespace SnakeGrowth
{
    using System;
    using Position;
    using System.Collections.Generic;

    public static class SnakeGrowthManager
    {
        public static void MakeTheSnakeBiggerAfterItAteFood(Queue<Position> snake)
        {
            Position tail = snake.Peek();
            Position nextToTheTailElement = CheckTheNearestPositionOfAnElement(snake, tail);

            int rowDiff = tail.Row - nextToTheTailElement.Row;
            int colDiff = tail.Col - nextToTheTailElement.Col;
        }

        private static Position CheckTheNearestPositionOfAnElement(Queue<Position> snake, Position tail)
        {
            Position[] snakeHolder = snake.ToArray();

            return snakeHolder[1];
        }
    }
}
