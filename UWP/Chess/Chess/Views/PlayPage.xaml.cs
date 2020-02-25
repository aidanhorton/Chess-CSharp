using Windows.UI.Xaml.Controls;
using Chess.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Chess.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayPage : Page
    {
        public PlayPage()
        {
            this.InitializeComponent();

            this.ViewModel = new PlayPageViewModel();
        }

        public PlayPageViewModel ViewModel { get; set; }
    }
}