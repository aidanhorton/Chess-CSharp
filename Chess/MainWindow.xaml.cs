using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        private void ChessCellClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var position = new Position(this.EvaluateLetter(button.Name[0]), 8 - (button.Name[1] - '0'));
            }
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
