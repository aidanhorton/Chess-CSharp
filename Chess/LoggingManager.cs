namespace Chess
{
    public class LoggingManager
    {
        public LoggingManager(GameManager manager)
        {
            this._gameManager = manager;
        }

        private GameManager _gameManager;
    }
}
