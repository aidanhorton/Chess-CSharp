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
                // TODO - Get rid of code duplication in the piece checking
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
    }
}
