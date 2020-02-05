using System.Collections.Generic;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Position position, Color color)
            : base(position, color, PieceType.Rook)
        {
        }

        // TODO - Needs to be re-done and optimized
        public override IEnumerable<Position> GetValidMoves()
        {
            // Valid moves up.
            for (var y = 1; y < 8 - this.Position.Y; y++)
            {
                var newPosition = new Position(this.Position.X, this.Position.Y + y);
                var pieceAtLocation = PieceManager.GetPieceInBoard(newPosition);

                if (pieceAtLocation == null)
                {
                    yield return newPosition;
                    continue;
                }

                if (pieceAtLocation.Color == this.Color)
                {
                    break;
                }

                yield return newPosition;
                break;
            }
            
            // Valid moves down.
            for (var y = 1; y <= this.Position.Y; y++)
            {
                var newPosition = new Position(this.Position.X, this.Position.Y - y);
                var pieceAtLocation = PieceManager.GetPieceInBoard(newPosition);

                if (pieceAtLocation == null)
                {
                    yield return newPosition;
                    continue;
                }

                if (pieceAtLocation.Color == this.Color)
                {
                    break;
                }

                yield return newPosition;
                break;
            }

            // Valid moves right.
            for (var x = 1; x < 8 - this.Position.X; x++)
            {
                var newPosition = new Position(this.Position.X + x, this.Position.Y);
                var pieceAtLocation = PieceManager.GetPieceInBoard(newPosition);

                if (pieceAtLocation == null)
                {
                    yield return newPosition;
                    continue;
                }

                if (pieceAtLocation.Color == this.Color)
                {
                    break;
                }

                yield return newPosition;
                break;
            }

            // Valid moves left.
            for (var x = 1; x <= this.Position.X; x++)
            {
                var newPosition = new Position(this.Position.X - x, this.Position.Y);
                var pieceAtLocation = PieceManager.GetPieceInBoard(newPosition);

                if (pieceAtLocation == null)
                {
                    yield return newPosition;
                    continue;
                }

                if (pieceAtLocation.Color == this.Color)
                {
                    break;
                }

                yield return newPosition;
                break;
            }
        }

        public override bool IsValidMove(Position destination)
        {
            if (destination.X != this.Position.X && destination.Y != this.Position.Y)
            {
                return false;
            }

            if (destination.X != this.Position.X)
            {
                // TODO - Get rid of code duplication in the piece checking
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
    }
}
