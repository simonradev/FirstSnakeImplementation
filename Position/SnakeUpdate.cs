namespace Position
{
    using System.Collections.Generic;
    using System.Linq;
    using Validation;

    public static class SnakeUpdate
    {
        public static bool UpdateTheSnake(Queue<Position> snake, Position newHeadPosition)
        {
            Position head = snake.Last();
            snake.Dequeue();
            Position newHead = new Position(head.Row + newHeadPosition.Row, head.Col + newHeadPosition.Col);

            PositionCheck.CheckIfSnakeCollidesIntoItself(snake, newHead);
            bool snakeAteFood = PositionCheck.CheckIfTheSnakeHadSomeFood(newHead);

            snake.Enqueue(newHead);

            return snakeAteFood;
        } 

        private static void MakeTheSnakeBiggerAfterItAteFood(Queue<Position> snake)
        {
            Position[] snakeHolder = snake.ToArray();


        }
    }
}
