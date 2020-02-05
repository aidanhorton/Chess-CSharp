using Chess.Pieces;

namespace Chess
{
    public class PieceManager
    {
        public static Piece GetPieceInBoard(Position position)
        {
            return PieceBoard[position.Y].GetPiece(position.X);
        }

        public void MovePiece(Position position, Piece piece)
        {
            var originalPosition = piece.Position;

            this.SetPieceInBoard(position, piece);
            this.SetPieceInBoard(originalPosition, null);
        }

        private void SetPieceInBoard(Position position, Piece piece)
        {
            if (piece != null)
            {
                piece.Position = position;
            }
            
            PieceBoard[position.Y].SetPiece(position.X, piece);
        }

        public static PieceRow[] PieceBoard = 
        {
            new PieceRow(
                new Rook(new Position(0, 0), Color.White),
                new Knight(new Position(1, 0), Color.White),
                new Bishop(new Position(2, 0), Color.White),
                new Queen(new Position(3, 0), Color.White),
                new King(new Position(4, 0), Color.White),
                new Bishop(new Position(5, 0), Color.White),
                new Knight(new Position(6, 0), Color.White),
                new Rook(new Position(7, 0), Color.White)),

            new PieceRow(
                null,
                new Pawn(new Position(1, 1), Color.White),
                new Pawn(new Position(2, 1), Color.White),
                new Pawn(new Position(3, 1), Color.White),
                new Pawn(new Position(4, 1), Color.White),
                new Pawn(new Position(5, 1), Color.White),
                new Pawn(new Position(6, 1), Color.White),
                new Pawn(new Position(7, 1), Color.White)),

            new PieceRow(),
            new PieceRow(),
            new PieceRow(),
            new PieceRow(),

            new PieceRow(
                new Pawn(new Position(0, 6), Color.Black),
                new Pawn(new Position(1, 6), Color.Black),
                new Pawn(new Position(2, 6), Color.Black),
                new Pawn(new Position(3, 6), Color.Black),
                new Pawn(new Position(4, 6), Color.Black),
                new Pawn(new Position(5, 6), Color.Black),
                new Pawn(new Position(6, 6), Color.Black),
                new Pawn(new Position(7, 6), Color.Black)),

            new PieceRow(
                new Rook(new Position(0, 7), Color.Black),
                new Knight(new Position(1, 7), Color.Black),
                new Bishop(new Position(2, 7), Color.Black),
                new Queen(new Position(3, 7), Color.Black),
                new King(new Position(4, 7), Color.Black),
                new Bishop(new Position(5, 7), Color.Black),
                new Knight(new Position(6, 7), Color.Black),
                new Rook(new Position(7, 7), Color.Black))
        };
    }

    public class PieceRow
    {
        public Piece[] Pieces = new Piece[8];

        public PieceRow(params Piece[] pieces)
        {
            for (var i = 0; i < pieces.Length; i++)
            {
                this.Pieces[i] = pieces[i];
            }
        }

        public Piece GetPiece(int xPos)
        {
            return this.Pieces[xPos];
        }

        public void SetPiece(int xPos, Piece piece)
        {
            this.Pieces[xPos] = piece;
        }
    }
}
