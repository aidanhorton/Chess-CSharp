using System.Collections.ObjectModel;
using Chess.DataTypes;

namespace Chess.ViewModels
{
    public class PlayPageViewModel : ViewModelBase
    {
        private ObservableCollection<BoardDataItem> _boardDataItems;

        public PlayPageViewModel()
        {
            this.PopulateBoardDataItems();
        }

        public ObservableCollection<BoardDataItem> BoardDataItems
        {
            get => this._boardDataItems;
            set => this.SetProperty(ref this._boardDataItems, value);
        }

        private void PopulateBoardDataItems()
        {
            this.BoardDataItems = new ObservableCollection<BoardDataItem>()
            {
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light, "/Images/QueenBlack.png"),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),

                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),

                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),

                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),

                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),

                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),

                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),

                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark),
                new BoardDataItem(BoardSquare.Light),
                new BoardDataItem(BoardSquare.Dark)
            };
        }
    }
}
