namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Position position, Color color)
            : base(position, color, PieceType.Pawn)
        {
        }

        public override bool IsValidMove(Position position)
        {
            return true;
        }
    }
}
