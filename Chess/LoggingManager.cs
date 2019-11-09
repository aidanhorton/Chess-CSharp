namespace Chess
{
    public class LoggingManager
    {
        public LoggingManager(GameManager manager)
        {
            this._gameManager = manager;
        }

        public void Log(string logString)
        {
            this._gameManager.Log(new LogEntry(logString));
        }

        private GameManager _gameManager;
    }
}
