namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; set; }
        public Item RoomItem { get; set; }
        public Monster RoomMonster { get; set; }

        public Room(string description, Item item, Monster monster)
        {
            Description = description;
            RoomItem = item;
            RoomMonster = monster;
        }
    }
}