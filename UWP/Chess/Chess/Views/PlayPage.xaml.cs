using Windows.UI.Xaml.Controls;
using Chess.DataTypes;
using Chess.Model.Board;
using Chess.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Chess.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayPage
    {
        private readonly HighlightedMove _highlightedMove;

        public PlayPage()
        {
            this.InitializeComponent();

            this.ViewModel = new PlayPageViewModel();
            this._highlightedMove = new HighlightedMove(this.ViewModel);
        }

        public PlayPageViewModel ViewModel { get; set; }

        private void BoardSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newSelection = e.AddedItems;

            if (newSelection == null || newSelection.Count == 0)
            {
                return;
            }

            if (!(newSelection[0] is BoardDataItem selectedItem))
            {
                return;
            }

            if ((selectedItem.PieceType.ToString().Contains("White") && this.ViewModel.IsWhiteMove) || (selectedItem.PieceType.ToString().Contains("Black") && !this.ViewModel.IsWhiteMove))
            {
                this._highlightedMove.TileToMoveFrom = selectedItem;

                return;
            }

            if (this._highlightedMove.TileToMoveFrom == null || this._highlightedMove.TileToMoveFrom.PieceType == PieceType.None)
            {
                return;
            }

            if (this.ViewModel.TryMove(this._highlightedMove.TileToMoveFrom.BoardIndex, selectedItem.BoardIndex))
            {
                // TODO - TileToMoveFrom gets deselected if you re-move the same piece.
                this.BoardGrid.SelectedItem = null;
                this._highlightedMove.TileToMoveTo = selectedItem;
            }
            else
            {
                this._highlightedMove.TileToMoveFrom = null;
            }
        }

        private class HighlightedMove
        {
            private readonly PlayPageViewModel _viewModel;

            private BoardDataItem _tileToMoveFrom;

            private BoardDataItem _tileToMoveTo;

            public HighlightedMove(PlayPageViewModel viewModel)
            {
                this._viewModel = viewModel;
            }

            public BoardDataItem TileToMoveFrom
            {
                get => this._tileToMoveFrom;
                set
                {
                    this.SetPieceHighlight(this._tileToMoveFrom);
                    this.SetPieceHighlight(this._tileToMoveTo);
                    this.SetPieceHighlight(value, TileSelectionMode.TileSelected);

                    this._tileToMoveFrom = value;
                }
            }

            public BoardDataItem TileToMoveTo
            {
                set
                {
                    this.SetPieceHighlight(this._tileToMoveTo);
                    this.SetPieceHighlight(value, TileSelectionMode.TileSelected);

                    this._tileToMoveTo = value;
                }
            }

            private void SetPieceHighlight(BoardDataItem piece, TileSelectionMode tileSelectionMode = TileSelectionMode.TileUnselected)
            {
                if (piece == null)
                {
                    return;
                }

                this._viewModel.BoardDataItems[piece.BoardIndex].SetBackgroundColor(tileSelectionMode);
            }
        }
    }
}