using System;
using Windows.UI.Xaml.Controls;
using Chess.ViewModels;
using Chess.Views;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewItem = Microsoft.UI.Xaml.Controls.NavigationViewItem;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Chess
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Type _defaultPage = typeof(HomePage);

        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new MainPageViewModel();

            this.NavigationService.Navigate(_defaultPage);
        }

        public MainPageViewModel ViewModel { get; set; }

        private void NavigationView_SelectionChanged(NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs selectedPage)
        {
            if (selectedPage.IsSettingsSelected)
            {
                this.NavigationService.Navigate(typeof(SettingsPage));
                return;
            }
            
            var selectedItem = (NavigationViewItem)selectedPage.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            var pageTag = (string) selectedItem.Tag;
            if (string.IsNullOrEmpty(pageTag))
            {
                return;
            }

            var pageType = Type.GetType($"Chess.Views.{pageTag}");

            if (pageType != this.NavigationService.SourcePageType)
            {
                this.NavigationService.Navigate(pageType);
            }
        }
    }
}
