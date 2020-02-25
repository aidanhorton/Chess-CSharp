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

            this.PopulateBoardDataItems();
        }

        public ObservableCollection<BoardDataItem> BoardDataItems
        {
            get => this._boardDataItems;
            set => this.SetProperty(ref this._boardDataItems, value);
        }

        private void UpdateBoard(PieceType[] pieces)
        {
            this._boardDataItems = new ObservableCollection<BoardDataItem>();

            for (var i = 0; i < pieces.Length; i++)
            {
                this.BoardDataItems.Add(new BoardDataItem(
                    EvaluateSquareStyle(i), 
                    $"/Images/{pieces[i].ToString()}.png"));
            }
        }

        private static BoardSquare EvaluateSquareStyle(int squareIndex)
        {
            return (squareIndex % 8 + squareIndex / 8 % 2) % 2 == 0 
                ? BoardSquare.Dark 
                : BoardSquare.Light;
        }

        private void PopulateBoardDataItems()
        {
            PieceType[] pieces =
            {
                PieceType.WhiteRook,
                PieceType.WhiteKnight,
                PieceType.WhiteBishop,
                PieceType.WhiteQueen,
                PieceType.WhiteKing,
                PieceType.WhiteBishop,
                PieceType.WhiteKnight,
                PieceType.WhiteRook,

                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,
                PieceType.WhitePawn,

                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,

                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,

                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,

                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,
                PieceType.None,

                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,
                PieceType.BlackPawn,

                PieceType.BlackRook,
                PieceType.BlackKnight,
                PieceType.BlackBishop,
                PieceType.BlackQueen,
                PieceType.BlackKing,
                PieceType.BlackBishop,
                PieceType.BlackKnight,
                PieceType.BlackRook
            };

            this._boardUpdater.UpdateBoard(pieces);
        }
    }
}
