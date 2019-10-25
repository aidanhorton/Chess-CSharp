﻿using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class PieceManager
    {
        public List<Piece> Pieces = new List<Piece>();

        public PieceManager()
        {
            this.PopulatePieces();
        }

        public Piece GetPiece(Position position)
        {
            return this.Pieces.FirstOrDefault(piece => piece.Position.Equals(position));
        }

        private void PopulatePieces()
        {
            //Black Pieces
            this.Pieces.Add(new Piece(new Position(0, 0), Color.Black, PieceType.Rook));
            this.Pieces.Add(new Piece(new Position(1, 0), Color.Black, PieceType.Knight));
            this.Pieces.Add(new Piece(new Position(2, 0), Color.Black, PieceType.Bishop));
            this.Pieces.Add(new Piece(new Position(3, 0), Color.Black, PieceType.Queen));
            this.Pieces.Add(new Piece(new Position(4, 0), Color.Black, PieceType.King));
            this.Pieces.Add(new Piece(new Position(5, 0), Color.Black, PieceType.Bishop));
            this.Pieces.Add(new Piece(new Position(6, 0), Color.Black, PieceType.Knight));
            this.Pieces.Add(new Piece(new Position(7, 0), Color.Black, PieceType.Rook));

            this.Pieces.Add(new Piece(new Position(0, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(1, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(2, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(3, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(4, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(5, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(6, 1), Color.Black, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(7, 1), Color.Black, PieceType.Pawn));

            //White Pieces
            this.Pieces.Add(new Piece(new Position(0, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(1, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(2, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(3, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(4, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(5, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(6, 6), Color.White, PieceType.Pawn));
            this.Pieces.Add(new Piece(new Position(7, 6), Color.White, PieceType.Pawn));

            this.Pieces.Add(new Piece(new Position(0, 7), Color.White, PieceType.Rook));
            this.Pieces.Add(new Piece(new Position(1, 7), Color.White, PieceType.Knight));
            this.Pieces.Add(new Piece(new Position(2, 7), Color.White, PieceType.Bishop));
            this.Pieces.Add(new Piece(new Position(3, 7), Color.White, PieceType.Queen));
            this.Pieces.Add(new Piece(new Position(4, 7), Color.White, PieceType.King));
            this.Pieces.Add(new Piece(new Position(5, 7), Color.White, PieceType.Bishop));
            this.Pieces.Add(new Piece(new Position(6, 7), Color.White, PieceType.Knight));
            this.Pieces.Add(new Piece(new Position(7, 7), Color.White, PieceType.Rook));
        }
    }
}