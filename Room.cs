namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; set; }
        public string Item { get; set; }

        // Constructor for Room
        public Room(string description, string item = "No item")
        {
            Description = description;
            Item = item;
        }
    }
}