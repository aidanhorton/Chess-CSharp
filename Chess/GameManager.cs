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

        private MainWindow _mainWindow;
    }
}
