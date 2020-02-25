using Chess.Model.Board;

namespace Chess.Model.Interpretation
{
    public class ForsythEdwardsInterpreter : IInterpreter
    {
        public PieceType[] Interpret(string interpretationText)
        {
            return new PieceType[64];
        }
    }
}