using System;

namespace Chess.Model.Board
{
    public class BoardStore
    {
        internal UInt64 WhiteKing;
        internal UInt64 WhiteQueens;
        internal UInt64 WhiteRooks;
        internal UInt64 WhiteBishops;
        internal UInt64 WhiteKnights;
        internal UInt64 WhitePawns;
        internal UInt64 WhitePieces;

        internal UInt64 BlackKing;
        internal UInt64 BlackQueens;
        internal UInt64 BlackRooks;
        internal UInt64 BlackBishops;
        internal UInt64 BlackKnights;
        internal UInt64 BlackPawns;
        internal UInt64 BlackPieces;

        internal UInt64 SquaresOccupied;

        private void CreatePieceBitBoards()
        {
            for (Int16 i = 0; i < 64; i++)
            {
                // Populate board here.
                // Reference https://stackoverflow.com/questions/9635214/how-can-i-implement-a-bitboard-in-vb-net

                this.WhiteKing |= BitwiseHelpers.BitRepresentationOfBoardSquareNumber(i);
            }

            this.WhitePieces = this.WhiteKing | this.WhiteQueens |
                               this.WhiteRooks | this.WhiteBishops |
                               this.WhiteKnights | this.WhitePawns;

            this.BlackPieces = this.BlackKing | this.BlackQueens |
                               this.BlackRooks | this.BlackBishops |
                               this.BlackKnights | this.BlackPawns;

            this.SquaresOccupied = this.WhitePieces | this.BlackPieces;
        }
    }
}
