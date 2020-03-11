using Windows.UI;
using Windows.UI.Xaml.Media;
using Chess.Model.Board;
using Chess.ViewModels;

namespace Chess.DataTypes
{
    public class BoardDataItem : ViewModelBase
    {
        private TileHighlight _boardTileHighlight;

        private string _imagePath;

        private SolidColorBrush _backgroundColor;

        public BoardDataItem(PieceType pieceType, int boardIndex)
        {
            this.PieceType = pieceType;
            this.BoardIndex = boardIndex;

            this.EvaluateImagePath();
            this.EvaluateTileStyle(boardIndex);

            this.SetBackgroundColor();
        }

        public string ImagePath
        {
            get => this._imagePath;
            private set => this.SetProperty(ref this._imagePath, value, nameof(this.ImagePath));
        }

        public SolidColorBrush BackgroundColor
        {
            get => this._backgroundColor;
            private set => this.SetProperty(ref this._backgroundColor, value, nameof(this.BackgroundColor));
        }

        public PieceType PieceType { get; private set; }

        public int BoardIndex { get; }

        public void UpdatePieceType(PieceType newPieceType)
        {
            this.PieceType = newPieceType;
            this.EvaluateImagePath();
        }

        public void SetBackgroundColor(TileSelectionMode selectionMode = TileSelectionMode.TileUnselected)
        {
            if (this._boardTileHighlight == TileHighlight.Dark)
            {
                if (selectionMode == TileSelectionMode.TileSelected)
                {
                    this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 170, 162, 58));
                    return;
                }

                this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 181, 136, 99));
                return;
            }

            if (selectionMode == TileSelectionMode.TileSelected)
            {
                this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 205, 210, 106));
                return;
            }

            this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 240, 217, 181));
        }

        private void EvaluateTileStyle(int squareIndex)
        {
            this._boardTileHighlight = (squareIndex % 8 + squareIndex / 8 % 2) % 2 == 0
                ? TileHighlight.Dark
                : TileHighlight.Light;
        }

        private void EvaluateImagePath()
        {
            // Must return a URI that isn't null or ''
            this.ImagePath = this.PieceType != PieceType.None
                ? $"/Images/{this.PieceType.ToString()}.png"
                : "x";
        }
    }

    public enum TileHighlight
    {
        Dark,
        Light
    }

    public enum TileSelectionMode
    {
        TileSelected,
        TileUnselected
    }
}