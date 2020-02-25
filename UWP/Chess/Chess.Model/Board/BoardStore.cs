using System;

namespace Chess.Model.Board
{
    public delegate void BoardUpdateEventHandler(PieceType[] pieces);

    public class BoardStore : IBoardUpdate
    {
        public event BoardUpdateEventHandler BoardUpdated;

        internal UInt64 WhiteKing;
        internal UInt64 WhiteQueens;
        internal UInt64 WhiteRooks;
        internal UInt64 WhiteBishops;
        internal UInt64 WhiteKnights;
        internal UInt64 WhitePawns;

        internal UInt64 BlackKing;
        internal UInt64 BlackQueens;
        internal UInt64 BlackRooks;
        internal UInt64 BlackBishops;
        internal UInt64 BlackKnights;
        internal UInt64 BlackPawns;

        internal UInt64 WhitePieces;
        internal UInt64 BlackPieces;

        internal UInt64 SquaresOccupied;

        public void UpdateBoard(PieceType[] pieces)
        {
            if (pieces.Length != 64)
            {
                throw new Exception("Piece array to populate bit-board from is not 64 squares!");
            }

            this.ResetBitBoards();

            for (Int16 i = 0; i < 64; i++)
            {
                // Populate board here.
                // Reference https://stackoverflow.com/questions/9635214/how-can-i-implement-a-bitboard-in-vb-net

                if (pieces[i] == PieceType.WhiteKing)
                {
                    this.WhiteKing |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.WhiteQueen)
                {
                    this.WhiteQueens |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.WhiteRook)
                {
                    this.WhiteRooks |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.WhiteBishop)
                {
                    this.WhiteBishops |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.WhiteKnight)
                {
                    this.WhiteKnights |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.WhitePawn)
                {
                    this.WhitePawns |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackKing)
                {
                    this.BlackKing |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackQueen)
                {
                    this.BlackQueens |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackRook)
                {
                    this.BlackRooks |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackBishop)
                {
                    this.BlackBishops |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackKnight)
                {
                    this.BlackKnights |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
                else if (pieces[i] == PieceType.BlackPawn)
                {
                    this.BlackPawns |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
                }
            }

            this.WhitePieces = this.WhiteKing | this.WhiteQueens |
                               this.WhiteRooks | this.WhiteBishops |
                               this.WhiteKnights | this.WhitePawns;

            this.BlackPieces = this.BlackKing | this.BlackQueens |
                               this.BlackRooks | this.BlackBishops |
                               this.BlackKnights | this.BlackPawns;

            this.SquaresOccupied = this.WhitePieces | this.BlackPieces;

            this.BoardUpdated(pieces);
        }

        private void ResetBitBoards()
        {
            this.WhiteKing = 0;
            this.WhiteQueens = 0;
            this.WhiteRooks = 0;
            this.WhiteBishops = 0;
            this.WhiteKnights = 0;
            this.WhitePawns = 0;
            this.WhitePieces = 0;

            this.BlackKing = 0;
            this.BlackQueens = 0;
            this.BlackRooks = 0;
            this.BlackBishops = 0;
            this.BlackKnights = 0;
            this.BlackPawns = 0;
            this.BlackPieces = 0;
        }
    }
}