using System;

namespace Chess.Model.Board
{
    public class BoardStore
    {
        internal ulong WhiteKing;
        internal ulong WhiteQueens;
        internal ulong WhiteRooks;
        internal ulong WhiteBishops;
        internal ulong WhiteKnights;
        internal ulong WhitePawns;
        internal ulong WhitePieces;

        internal ulong BlackKing;
        internal ulong BlackQueens;
        internal ulong BlackRooks;
        internal ulong BlackBishops;
        internal ulong BlackKnights;
        internal ulong BlackPawns;
        internal ulong BlackPieces;

        internal ulong SquaresOccupied;

        private void CreatePieceBitBoards()
        {
            for (ulong i = 0; i < 64; i++)
            {
                // Populate board here.
                // Reference https://stackoverflow.com/questions/9635214/how-can-i-implement-a-bitboard-in-vb-net
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
