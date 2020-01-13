using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Chess
{
    public class PieceManager
    {
        public Piece GetPieceInBoard(Position position)
        {
            return this.PieceBoard[position.Y].GetPiece(position.X);
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
            
            this.PieceBoard[position.Y].SetPiece(position.X, piece);
        }

        public PieceRow[] PieceBoard = new PieceRow[8]
        {
            new PieceRow(
                new Piece(new Position(0, 0), Color.White, PieceType.Rook),
                new Piece(new Position(1, 0), Color.White, PieceType.Knight),
                new Piece(new Position(2, 0), Color.White, PieceType.Bishop),
                new Piece(new Position(3, 0), Color.White, PieceType.Queen),
                new Piece(new Position(4, 0), Color.White, PieceType.King),
                new Piece(new Position(5, 0), Color.White, PieceType.Bishop),
                new Piece(new Position(6, 0), Color.White, PieceType.Knight),
                new Piece(new Position(7, 0), Color.White, PieceType.Rook)),

            new PieceRow(
                new Piece(new Position(0, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(1, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(2, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(3, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(4, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(5, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(6, 1), Color.White, PieceType.Pawn),
                new Piece(new Position(7, 1), Color.White, PieceType.Pawn)),

            new PieceRow(),
            new PieceRow(),
            new PieceRow(),
            new PieceRow(),

            new PieceRow(
                new Piece(new Position(0, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(1, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(2, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(3, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(4, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(5, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(6, 6), Color.Black, PieceType.Pawn),
                new Piece(new Position(7, 6), Color.Black, PieceType.Pawn)),

            new PieceRow(
                new Piece(new Position(0, 7), Color.Black, PieceType.Rook),
                new Piece(new Position(1, 7), Color.Black, PieceType.Knight),
                new Piece(new Position(2, 7), Color.Black, PieceType.Bishop),
                new Piece(new Position(3, 7), Color.Black, PieceType.Queen),
                new Piece(new Position(4, 7), Color.Black, PieceType.King),
                new Piece(new Position(5, 7), Color.Black, PieceType.Bishop),
                new Piece(new Position(6, 7), Color.Black, PieceType.Knight),
                new Piece(new Position(7, 7), Color.Black, PieceType.Rook))
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
