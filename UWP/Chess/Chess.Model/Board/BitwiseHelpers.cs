using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
