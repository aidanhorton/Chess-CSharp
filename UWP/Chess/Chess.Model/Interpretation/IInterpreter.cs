using Chess.Model.Board;

namespace Chess.Model.Interpretation
{
    public interface IInterpreter
    {
        PieceCollection Interpret(string interpretationText);
    }
}