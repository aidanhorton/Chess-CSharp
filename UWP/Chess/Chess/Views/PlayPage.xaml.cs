using Windows.UI.Xaml.Controls;
using Chess.DataTypes;
using Chess.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Chess.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayPage : Page
    {
        private BoardDataItem currentSelectedPiece;

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

            if (selectedItem.PieceType.ToString().Contains("White") && this.ViewModel.IsWhiteMove)
            {
                // Assign to current selected piece, or if valid piece already then try to move through new viewmodel 'trymove' method
                // If not white move then deselect
            }
            else if (selectedItem.PieceType.ToString().Contains("Black") && !this.ViewModel.IsWhiteMove)
            {
                // Assign to current selected piece, or if valid piece already then try to move through new viewmodel 'trymove' method
                // If not white move then deselect
            }
            else
            {
                // Deselect
            }
        }
    }
}