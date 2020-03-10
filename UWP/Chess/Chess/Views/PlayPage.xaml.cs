using Windows.UI.Xaml.Controls;
using Chess.DataTypes;
using Chess.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Chess.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayPage
    {
        private BoardDataItem _currentSelectedPiece;

        public PlayPage()
        {
            this.InitializeComponent();

            this.ViewModel = new PlayPageViewModel();
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
                this.SetCurrentSelectedPiece(selectedItem);

                return;
            }

            if (this._currentSelectedPiece == null)
            {
                return;
            }

            if (this.ViewModel.TryMove(this._currentSelectedPiece.BoardIndex, selectedItem.BoardIndex))
            {
                // Keep a record to keep the pieces highlighted for the next move
                // Reset pieces highlighted from previous move.

                this.ResetCurrentSelectedPiece();
            }
            else
            {
                this.ResetCurrentSelectedPiece();
            }
        }

        private void ResetCurrentSelectedPiece()
        {
            if (this._currentSelectedPiece == null)
            {
                return;
            }

            this.ViewModel.BoardDataItems[this._currentSelectedPiece.BoardIndex].SetBackgroundColor();
            this._currentSelectedPiece = null;
        }

        private void SetCurrentSelectedPiece(BoardDataItem newPiece)
        {
            this.ResetCurrentSelectedPiece();

            this._currentSelectedPiece = newPiece;
            this.ViewModel.BoardDataItems[this._currentSelectedPiece.BoardIndex].SetBackgroundColor(TileSelectionMode.TileSelected);
        }
    }
}