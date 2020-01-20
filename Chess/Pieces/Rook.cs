using System;
using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Position position, Color color)
            : base(position, color, PieceType.Rook)
        {
        }

        public override bool IsValidMove(Position position)
        {
            if (position.X != this.Position.X && position.Y != this.Position.Y)
            {
                return false;
            }

            if (position.X != this.Position.X)
            {
                foreach (var newXPosition in this.GetEnumerationBetweenValues(this.Position.X, position.X))
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
                    if (newXPosition != position.X)
                    {
                        return false;
                    }
                }

                return true;
            }

            /*
             * Something weird maybe the X and Y is flipped, or upside-down
             * But its detecting pawns and other pieces where it shouldn't be detecting pieces
             *
             *
             *
             */

            foreach (var newYPosition in this.GetEnumerationBetweenValues(this.Position.Y, position.Y))
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
                if (newYPosition != position.Y)
                {
                    return false;
                }
            }

            return true;
        }

        private IEnumerable<int> GetEnumerationBetweenValues(int initialValue, int newValue)
        {
            var multiplier = newValue < initialValue ? -1 : 1;
            var difference = Math.Abs(newValue - this.Position.X);

            for (var i = 1; i <= difference; i++)
            {
                yield return initialValue + i * multiplier;
            }
        }
    }
}
