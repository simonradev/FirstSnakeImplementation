namespace Position
{
    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        public Position ToPosition()
        {
            Position toReturn = new Position(row, col);

            return toReturn;
        }
    }
}
