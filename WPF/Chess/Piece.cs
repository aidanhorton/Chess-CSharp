﻿using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        public Position Position;

        public Color Color;

        public PieceType PieceType;

        protected Position OriginalPosition;

        protected Piece(Position position, Color color, PieceType pieceType)
        {
            this.Position = position;
            this.OriginalPosition = position;
            this.Color = color;
            this.PieceType = pieceType;
        }

        public abstract IEnumerable<Position> GetValidMoves();

        public abstract bool IsValidMove(Position destination);

        protected IEnumerable<int> GetEnumerationBetweenValues(int initialValue, int newValue)
        {
            var multiplier = newValue < initialValue ? -1 : 1;
            var difference = Math.Abs(newValue - initialValue);

            for (var i = 1; i <= difference; i++)
            {
                yield return initialValue + i * multiplier;
            }
        }
    }

    public enum PieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public enum Color
    {
        Black,
        White,
        None
    }
}
