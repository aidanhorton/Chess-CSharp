using Chess.Views;

namespace Chess
{
    public class GameManager
    {
        public LoggingManager LogManager;

        public PieceManager PieceManager;

        public Turn CurrentTurn = Turn.Player;

        public GameManager(MainWindow window)
        {
            this._mainWindow = window;

            this.PieceManager = new PieceManager();

            this.UpdateBoardUi();
        }

        public void UpdateBoardUi()
        {
            this._mainWindow.UpdateBoardUi(PieceManager.PieceBoard);
        }

        public void Log(LogEntry logEntry)
        {
            this._mainWindow.Log.Add(logEntry);
        }

        private readonly MainWindow _mainWindow;
    }

    public enum Turn
    {
        Computer,
        Player
    }
}
