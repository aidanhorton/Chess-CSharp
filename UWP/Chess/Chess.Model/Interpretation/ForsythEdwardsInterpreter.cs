using System;
using System.Collections.Generic;
using Chess.Model.Board;

namespace Chess.Model.Interpretation
{
    public class ForsythEdwardsInterpreter : IInterpreter
    {
        public PieceCollection Interpret(string interpretationText)
        {
            // FEN is always from whites perspective.
            var fenSections = interpretationText.Split(' ');

            return InterpretPieceSection(fenSections[0]);
        }

        private static PieceCollection InterpretPieceSection(string boardRepresentation)
        {
            var rows = boardRepresentation.Split('/');

            var pieces = new PieceCollection();
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var currentColumn = 0;
                for (var charIndex = 0; charIndex < rows[rowIndex].Length; charIndex++)
                {
                    var pieceRepresentation = rows[rowIndex][charIndex];

                    if (PieceMap.TryGetValue(pieceRepresentation, out var piece))
                    {
                        pieces[rowIndex * 8 + currentColumn] = piece;
                        currentColumn++;

                        continue;
                    }

                    if (int.TryParse(pieceRepresentation.ToString(), out var emptySpaces))
                    {
                        for (var i = 0; i < emptySpaces; i++)
                        {
                            pieces[rowIndex * 8 + currentColumn] = PieceType.None;
                            currentColumn++;
                        }
                    }
                    else
                    {
                        throw new Exception($"Invalid piece detected during FEN interpretation - {pieceRepresentation}");
                    }
                }
            }

            return pieces;
        }

        private static readonly Dictionary<char, PieceType> PieceMap = new Dictionary<char, PieceType>()
        {
            { 'k', PieceType.BlackKing },
            { 'q', PieceType.BlackQueen },
            { 'r', PieceType.BlackRook },
            { 'b', PieceType.BlackBishop },
            { 'n', PieceType.BlackKnight },
            { 'p', PieceType.BlackPawn },

            { 'K', PieceType.WhiteKing },
            { 'Q', PieceType.WhiteQueen },
            { 'R', PieceType.WhiteRook },
            { 'B', PieceType.WhiteBishop },
            { 'N', PieceType.WhiteKnight },
            { 'P', PieceType.WhitePawn }
        };
    }
}