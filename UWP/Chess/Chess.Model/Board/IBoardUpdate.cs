namespace Chess.Model.Board
{
    public interface IBoardUpdate
    {
        event BoardUpdateEventHandler BoardUpdated;

        void UpdateBoard(PieceCollection pieces);

        PieceCollection GetBoard();
    }
}