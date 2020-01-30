using System;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Position position, Color color)
            : base(position, color, PieceType.Knight)
        {
        }

        public override bool IsValidMove(Position destination)
        {
            if (destination.X == this.Position.X || destination.Y == this.Position.Y)
            {
                return false;
            }

            if (Math.Abs(destination.X - this.Position.X) == 1)
            {
                if (Math.Abs(destination.Y - this.Position.Y) != 2)
                {
                    return false;
                }

                var pieceAtLocation = PieceManager.GetPieceInBoard(destination);

                if (pieceAtLocation == null)
                {
                    return true;
                }

                return pieceAtLocation.Color != this.Color;
            }

            if (Math.Abs(destination.Y - this.Position.Y) == 1)
            {
                if (Math.Abs(destination.X - this.Position.X) != 2)
                {
                    return false;
                }

                var pieceAtLocation = PieceManager.GetPieceInBoard(destination);

                if (pieceAtLocation == null)
                {
                    return true;
                }

                return pieceAtLocation.Color != this.Color;
            }

            return false;
        }
    }
}
