using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.Views
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

        public void UpdateBoardUi(PieceRow[] board)
        {
            this.ClearBoard();

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var piece = board[y].GetPiece(x);

                    if (piece == null)
                    {
                        continue;
                    }

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
                var position = new Position(EvaluateLetter(button.Name[0]), button.Name[1] - '0' - 1);
                var piece = PieceManager.GetPieceInBoard(position);

                if (piece != null && piece.Color == Color.White)
                {
                    this._pieceToMove = piece;

                    this._moveButtons.MoveFromButton = button;

                    return;
                }

                if (this._pieceToMove == null)
                {
                    return;
                }

                var validMoves = this._pieceToMove.GetValidMoves();
                if (!validMoves.Any(x => x.Equals(position)))
                {
                    return;
                }

                this.GameManager.PieceManager.MovePiece(position, this._pieceToMove);
                this.GameManager.UpdateBoardUi();
                this._pieceToMove = null;
                this._moveButtons.MoveToButton = button;
            }
        }

        public static int EvaluateLetter(char character)
        {
            var chessCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            return chessCharacters.IndexOf(character);
        }

        private string GetCellName(Position position)
        {
            var chessCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            return $"{chessCharacters[position.X]}{position.Y + 1}Image";
        }

        private void UpdateLogScroll(object sender, NotifyCollectionChangedEventArgs args)
        {
            this.GameLog.SelectedIndex = this.GameLog.Items.Count - 1;
            this.GameLog.ScrollIntoView(this.GameLog.SelectedItem);
        }

        private readonly ButtonMove _moveButtons = new ButtonMove();

        private Piece _pieceToMove;
    }

    internal class ButtonMove
    {
        public Button MoveFromButton
        {
            get => this._moveFromButton;
            set
            {
                this.RevertButton(this._moveFromButton);
                this.MoveToButton = null;

                this._moveFromButton = value;
                this.SelectButton(this._moveFromButton);
            }
        }

        public Button MoveToButton
        {
            get => this._moveToButton;
            set
            {
                this.RevertButton(this._moveToButton);

                this._moveToButton = value;
                this.SelectButton(this._moveToButton);
            }
        }

        private void SelectButton(Button button)
        {
            if (button == null)
            {
                return;
            }

            var position = new Position(MainWindow.EvaluateLetter(button.Name[0]), button.Name[1] - '0' - 1);
            button.Background = (position.X + position.Y) % 2 == 0
                ? Brushes.YellowGreen
                : Brushes.ForestGreen;
        }

        private void RevertButton(Button button)
        {
            if (button == null)
            {
                return;
            }

            var position = new Position(MainWindow.EvaluateLetter(button.Name[0]), button.Name[1] - '0' - 1);
            if ((position.X + position.Y) % 2 == 0)
            {
                button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffcc99");
            }
            else
            {
                button.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#996633");
            }
        }

        private Button _moveFromButton;

        private Button _moveToButton;
    }
}
