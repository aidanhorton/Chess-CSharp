using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Chess.DataTypes
{
    public class BoardDataItem
    {
        public BoardDataItem(BoardSquare boardSquare, string imagePath = null)
        {
            // Must return a URI that isn't null or ''
            this.ImagePath = imagePath ?? "x";

            this.SetBackgroundColor(boardSquare);
        }

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
    }

    public enum BoardSquare
    {
        Dark,
        Light
    }
}