namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Position position, Color color)
            : base(position, color, PieceType.Bishop)
        {
        }

        public override bool IsValidMove(Position position)
        {
            return true;
        }
    }
}
