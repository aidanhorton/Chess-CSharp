namespace Chess.Model.Board
{
    public interface IBoardUpdate
    {
        event BoardUpdateEventHandler BoardUpdated;

        void UpdateBoard(PieceType[] pieces);
    }
}