namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Position position, Color color)
            : base(position, color, PieceType.Queen)
        {
        }

        public override bool IsValidMove(Position position)
        {
            return true;
        }
    }
}
