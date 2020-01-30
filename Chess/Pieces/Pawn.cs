using System;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Position position, Color color)
            : base(position, color, PieceType.Pawn)
        {
        }

        public override bool IsValidMove(Position destination)
        {
            var yDistance = Math.Abs(this.Position.Y - destination.Y);

            if (yDistance <= 0 || yDistance > 2)
            {
                return false;
            }

            var xDistance = Math.Abs(this.Position.X - destination.X);
            if (yDistance == 2)
            {
                return this.IsFirstMove && xDistance == 0;
            }

            if (xDistance > 1)
            {
                return false;
            }

            var pieceAtLocation = PieceManager.GetPieceInBoard(destination);
            if (xDistance == 0)
            {
                return pieceAtLocation == null;
            }

            if (pieceAtLocation == null)
            {
                return false;
            }

            return pieceAtLocation.Color != this.Color;
        }
    }
}
