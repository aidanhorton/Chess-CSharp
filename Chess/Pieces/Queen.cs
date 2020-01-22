using System;
using System.Linq;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Position position, Color color)
            : base(position, color, PieceType.Queen)
        {
        }

        public override bool IsValidMove(Position destination)
        {
            if (destination.X == this.Position.X)
            {
                foreach (var newYPosition in this.GetEnumerationBetweenValues(this.Position.Y, destination.Y))
                {
                    var pieceAtLocation = PieceManager.GetPieceInBoard(new Position(this.Position.X, newYPosition));

                    if (pieceAtLocation == null)
                    {
                        continue;
                    }

                    if (pieceAtLocation.Color == this.Color)
                    {
                        return false;
                    }

                    // Can't jump over a piece.
                    if (newYPosition != destination.Y)
                    {
                        return false;
                    }
                }

                return true;
            }

            if (destination.Y == this.Position.Y)
            {
                foreach (var newXPosition in this.GetEnumerationBetweenValues(this.Position.X, destination.X))
                {
                    var pieceAtLocation = PieceManager.GetPieceInBoard(new Position(newXPosition, this.Position.Y));

                    if (pieceAtLocation == null)
                    {
                        continue;
                    }

                    if (pieceAtLocation.Color == this.Color)
                    {
                        return false;
                    }

                    // Can't jump over a piece.
                    if (newXPosition != destination.X)
                    {
                        return false;
                    }
                }

                return true;
            }

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
