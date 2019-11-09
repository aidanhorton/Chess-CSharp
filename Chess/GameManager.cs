namespace Chess
{
    public class GameManager
    {
        public LoggingManager LogManager;

        public PieceManager PieceManager;

        public GameManager(MainWindow window)
        {
            this._mainWindow = window;
        }

        public void Log(LogEntry logEntry)
        {
            this._mainWindow.Log.Add(logEntry);
        }

        private MainWindow _mainWindow;
    }
}
