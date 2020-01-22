using System;

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
            if (Math.Abs(destination.X - this.Position.X) > 1 || Math.Abs(destination.Y - this.Position.Y) > 1)
            {
                return false;
            }

            // Add 'check' checking.

            var pieceAtLocation = PieceManager.GetPieceInBoard(destination);

            if (pieceAtLocation == null)
            {
                return true;
            }

            return pieceAtLocation.Color != this.Color;
        }
    }
}
