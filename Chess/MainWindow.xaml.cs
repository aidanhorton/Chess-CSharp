using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ObservableCollection<LogEntry> Log = new ObservableCollection<LogEntry>();

        public GameManager GameManager;

        public MainWindow()
        {
            InitializeComponent();

            this.GameManager = new GameManager(this);

            this.GameLog.ItemsSource = Log;
            this.Log.CollectionChanged += UpdateLogScroll;
        }

        public void UpdateBoardUi(IEnumerable<Piece> pieces)
        {
            this.ClearBoard();

            foreach (var piece in pieces)
            {
                var cellImageName = this.GetCellName(piece.Position);
                var image = this.BoardGrid.FindName(cellImageName) as Image;
                if (image == null)
                {
                    Console.WriteLine("Image is invalid");
                    continue;
                }

                image.Source = new BitmapImage(new Uri($"Images/{piece.PieceType.ToString()}{piece.Color.ToString()}.png", UriKind.Relative));
            }
        }

        private void ClearBoard()
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var cellImageName = this.GetCellName(new Position(x, y));
                    var image = this.BoardGrid.FindName(cellImageName) as Image;
                    if (image == null)
                    {
                        Console.WriteLine("Image is invalid");
                        continue;
                    }

                    image.Source = null;
                }
            }
        }

        private void ChessCellClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var position = new Position(this.EvaluateLetter(button.Name[0]), 8 - (button.Name[1] - '0'));
            }
        }

        private string GetCellName(Position position)
        {
            var chessCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            return $"{chessCharacters[position.X]}{position.Y + 1}Image";
        }

        private int EvaluateLetter(char character)
        {
            var chessCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            return chessCharacters.IndexOf(character);
        }

        private void UpdateLogScroll(object sender, NotifyCollectionChangedEventArgs args)
        {
            this.GameLog.SelectedIndex = this.GameLog.Items.Count - 1;
            this.GameLog.ScrollIntoView(this.GameLog.SelectedItem);
        }

        private Position startingPosition;
    }
}
