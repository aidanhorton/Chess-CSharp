namespace Chess
{
    public class Position
    {
        public int X;
        public int Y;

        public Position()
        {

        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Position position)
        {
            return this.X == position.X && this.Y == position.Y;
        }
    }
}
