namespace Chess
{
    public class Piece
    {
        public Position Position;

        public Color Color;

        public PieceType PieceType;

        public Piece(Position position, Color color, PieceType pieceType)
        {
            this.Position = position;
            this.Color = color;
            this.PieceType = pieceType;
        }
    }

    public enum PieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public enum Color
    {
        Black,
        White,
        None
    }
}
