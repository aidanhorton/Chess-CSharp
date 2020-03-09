using System.Collections.ObjectModel;
using Chess.DataTypes;
using Chess.Model.Board;
using Chess.Unity;
using Unity;

namespace Chess.ViewModels
{
    public class PlayPageViewModel : ViewModelBase
    {
        private readonly IBoardUpdate _boardUpdater;

        private ObservableCollection<BoardDataItem> _boardDataItems;

        public PlayPageViewModel()
        {
            this._boardUpdater = ServiceLocator.Container.Resolve<IBoardUpdate>();
            this._boardUpdater.BoardUpdated += this.UpdateBoard;

            this.UpdateBoard(this._boardUpdater.GetBoard());
        }

        public bool IsWhiteMove { get; set; }

        public ObservableCollection<BoardDataItem> BoardDataItems
        {
            get => this._boardDataItems;
            set => this.SetProperty(ref this._boardDataItems, value);
        }

        public bool TryMove(int pieceToMoveIndex, int locationToMoveToIndex)
        {


            return false;
        }

        private void UpdateBoard(PieceCollection pieces)
        {
            this._boardDataItems = new ObservableCollection<BoardDataItem>();

            for (var i = 0; i < pieces.Length; i++)
            {
                this.BoardDataItems.Add(new BoardDataItem(pieces[i], i));
            }
        }
    }
}