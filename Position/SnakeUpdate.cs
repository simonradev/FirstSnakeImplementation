namespace Position
{
    using System.Collections.Generic;
    using System.Linq;

    public static class SnakeUpdate
    {
        public static Queue<Position> UpdateTheSnake(Queue<Position> snake, Position newHeadPosition)
        {
            Position head = snake.Last();
            snake.Dequeue();
            snake.Enqueue(new Position(head.Row + newHeadPosition.Row, head.Col + newHeadPosition.Col));

            return snake;
        } 
    }
}
