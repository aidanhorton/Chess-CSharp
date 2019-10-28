namespace Chess
{
    public class GameManager
    {
        public LoggingManager LogManager;

        public PieceManager PieceManager;

        public GameManager(MainWindow window)
        {
            this._mainWindow = window;

            this.PieceManager = new PieceManager();

            this.UpdateBoardUi();
        }

        private void UpdateBoardUi()
        {
            this._mainWindow.UpdateBoardUi(this.PieceManager.Pieces);
        }

        private MainWindow _mainWindow;
    }
}
