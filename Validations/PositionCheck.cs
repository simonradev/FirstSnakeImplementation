namespace Validation
{
    using System.Collections.Generic;
    using Position;
    using Excepions;
    using GlobalConstants;
    using Visualizing;

    public static class PositionCheck
    {
        public static bool CheckIfTheMoveIsValid(Position nextDirection, Position oldDirection)
        {
            bool isValid = true;

            int[] positionElements = new int[2];
            positionElements[0] = nextDirection.Row + oldDirection.Row;
            positionElements[1] = nextDirection.Col + oldDirection.Col;

            foreach (int element in positionElements)
            {
                if (element != 0)
                {
                    isValid = false;

                    break;
                }
            }

            return isValid;
        }

        public static bool CheckIfTheSnakeHadSomeFood(Position newHead)
        {
            bool snakeAteFood = false;

            if (newHead.Row == PrintItems.foodPosition.Row && newHead.Col == PrintItems.foodPosition.Col)
            {
                snakeAteFood = true;
            }

            return snakeAteFood;
        }

        public static void CheckIfSnakeCollidesIntoItself(Queue<Position> snake, Position newHead)
        {
            bool snakeCollided = false;

            foreach (Position currSnakePart in snake)
            {
                if (newHead.Row == currSnakePart.Row && newHead.Col == currSnakePart.Col)
                {
                    snakeCollided = true;
                    break;
                }
            }

            if (snakeCollided)
            {
                throw new GameOver(GlobalConstants.SelfBiteExceptionMessage);
            }
        }

        public static void CheckIfSnakeCollidesIntoAWall(Position head)
        {
            if ((head.Row < GlobalConstants.MinimumRowSize || head.Row >= GlobalConstants.MaximumRowSize) ||
                (head.Col < GlobalConstants.MinimumColumnSize || head.Col >= GlobalConstants.MaximumColumnlSize))
            {
                throw new GameOver(GlobalConstants.WallHitExceptionMessage);
            }
        }
    }
}
