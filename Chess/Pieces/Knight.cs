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

                var piece = PieceManager.GetPieceInBoard(destination);

                if (piece == null)
                {
                    return true;
                }

                return piece.Color != this.Color;
            }

            if (Math.Abs(destination.Y - this.Position.Y) == 1)
            {
                if (Math.Abs(destination.X - this.Position.X) != 2)
                {
                    return false;
                }

                var piece = PieceManager.GetPieceInBoard(destination);

                if (piece == null)
                {
                    return true;
                }

                return piece.Color != this.Color;
            }

            return false;
        }
    }
}
