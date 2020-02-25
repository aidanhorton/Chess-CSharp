using System;

namespace Chess.Model.Board
{
    public class BitwiseHelpers
    {
        public static UInt64 BitRepresentationOfBoardSquareNumber(int boardSquareNumber)
        {
            UInt64 startingBit = 1;
            return startingBit << boardSquareNumber;
        }
    }
}