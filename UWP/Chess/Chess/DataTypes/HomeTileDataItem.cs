namespace Chess.DataTypes
{
    public class HomeTileDataItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public HomeTileDataItem(string title, string description, string imagePath)
        {
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
        }
    }
}