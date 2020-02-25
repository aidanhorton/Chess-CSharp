using Chess.Model.Board;

namespace Chess.Model.Interpretation
{
    public interface IInterpreter
    {
        PieceType[] Interpret(string interpretationText);
    }
}