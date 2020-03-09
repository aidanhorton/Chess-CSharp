using Windows.UI;
using Windows.UI.Xaml.Media;
using Chess.Model.Board;

namespace Chess.DataTypes
{
    public class BoardDataItem
    {
        public BoardDataItem(PieceType pieceType, int boardIndex)
        {
            // Must return a URI that isn't null or ''
            this.ImagePath = pieceType != PieceType.None
                ? $"/Images/{pieceType.ToString()}.png"
                : "x";

            this.PieceType = pieceType;
            this.BoardIndex = boardIndex;

            this.SetBackgroundColor(EvaluateSquareStyle(boardIndex));
        }

        public PieceType PieceType { get; set; }

        public int BoardIndex { get; }

        public string ImagePath { get; set; }

        public SolidColorBrush BackgroundColor { get; set; }

        private void SetBackgroundColor(BoardSquare boardSquare)
        {
            if (boardSquare == BoardSquare.Dark)
            {
                this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 181, 136, 99));
                return;
            }

            this.BackgroundColor = new SolidColorBrush(Color.FromArgb(255, 240, 217, 181));
        }

        private static BoardSquare EvaluateSquareStyle(int squareIndex)
        {
            return (squareIndex % 8 + squareIndex / 8 % 2) % 2 == 0
                ? BoardSquare.Dark
                : BoardSquare.Light;
        }
    }

    public enum BoardSquare
    {
        Dark,
        Light
    }
}