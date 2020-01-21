namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(Position position, Color color)
            : base(position, color, PieceType.King)
        {
        }

        public override bool IsValidMove(Position destination)
        {
            return true;
        }
    }
}
