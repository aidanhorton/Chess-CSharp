namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Position position, Color color)
            : base(position, color, PieceType.Knight)
        {
        }

        public override bool IsValidMove(Position position)
        {
            return true;
        }
    }
}
