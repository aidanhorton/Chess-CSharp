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

        private PieceCollection _currentBoard;

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
            var boardCopy = new PieceCollection(this._currentBoard);

            boardCopy[locationToMoveToIndex] = boardCopy[pieceToMoveIndex];
            boardCopy[pieceToMoveIndex] = PieceType.None;

            this._boardUpdater.UpdateBoard(boardCopy);

            return true;
        }

        private void UpdateBoard(PieceCollection pieces)
        {
            // Persist background colors for selected pieces in the edge case that this
            //  method is called while pieces are selected? May not be necessary.
            // Persist could avoid flashing though if instead of creating a new list,
            //  we simply update the existing list.
            this._currentBoard = pieces;

            if (this.BoardDataItems == null)
            {
                this.BoardDataItems = new ObservableCollection<BoardDataItem>();

                for (var i = 0; i < pieces.Length; i++)
                {
                    this.BoardDataItems.Add(new BoardDataItem(pieces[i], i));
                }

                return;
            }

            for (var i = 0; i < pieces.Length; i++)
            {
                if (this.BoardDataItems[i].PieceType == pieces[i])
                {
                    continue;
                }

                this.BoardDataItems[i].UpdatePieceType(pieces[i]);
            }
        }
    }
}