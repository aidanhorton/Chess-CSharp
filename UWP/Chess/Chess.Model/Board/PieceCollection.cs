using System.Collections.Generic;

namespace Chess.Model.Board
{
    public class PieceCollection
    {
        private readonly PieceType[] _pieces = new PieceType[64];

        public int Length => this._pieces.Length;

        public PieceType this[int index]
        {
            get => this._pieces[index];
            set => this._pieces[index] = value;
        }
    }

    public static class PieceCollectionExtensions
    {
        public static void AddPieceToCollection(this PieceCollection collection, PieceType pieceType, params int[] squarePositions)
        {
            foreach (var position in squarePositions)
            {
                collection[position] = pieceType;
            }
        }
    }
}