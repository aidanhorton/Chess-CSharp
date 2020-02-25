using System.Collections.ObjectModel;
using Chess.DataTypes;
using Chess.Model.Board;
using Chess.Model.Interpretation;
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
            var interpreter = new ForsythEdwardsInterpreter();

            var pieces = interpreter.Interpret("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

            this._boardUpdater.UpdateBoard(pieces);
        }
    }
}