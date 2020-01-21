using System;
using System.Linq;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Position position, Color color)
            : base(position, color, PieceType.Bishop)
        {
        }

        public override bool IsValidMove(Position destination)
        {
            // The piece is not on a valid diagonal tile.
            if (Math.Abs(destination.X - this.Position.X) != Math.Abs(destination.Y - this.Position.Y))
            {
                return false;
            }

            var xEnumeration = this.GetEnumerationBetweenValues(this.Position.X, destination.X).ToArray();
            var yEnumeration = this.GetEnumerationBetweenValues(this.Position.Y, destination.Y).ToArray();

            for (var i = 0; i < xEnumeration.Length; i++)
            {
                var pieceAtLocation = PieceManager.GetPieceInBoard(new Position(xEnumeration[i], yEnumeration[i]));

                if (pieceAtLocation == null)
                {
                    continue;
                }

                if (pieceAtLocation.Color == this.Color)
                {
                    return false;
                }

                if (i < xEnumeration.Length - 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
