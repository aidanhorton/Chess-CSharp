using System.Collections.ObjectModel;
using Chess.DataTypes;

namespace Chess.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ObservableCollection<HomeTileDataItem> _tiles;

        public HomePageViewModel()
        {
            this._tiles = new ObservableCollection<HomeTileDataItem>()
            {
                new HomeTileDataItem("Yes", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("Another title", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("Yet another", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("Please no more", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("Sorry, but more", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("Home page", "This is a description for this item", "/Images/Animations.png"),
                new HomeTileDataItem("This and that", "This is a description for this item", "/Images/Animations.png")

            };
        }

        public ObservableCollection<HomeTileDataItem> Tiles
        {
            get => this._tiles;
            set => this.SetProperty(ref this._tiles, value);
        }
    }
}