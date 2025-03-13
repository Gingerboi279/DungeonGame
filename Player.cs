using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; set; }
        public string Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = string.Empty;
        }

        public void PickUpItem(string item)
        {
            if (string.IsNullOrEmpty(Inventory))
            {
                Inventory = item;
                Console.WriteLine($"You have picked up the {item}.");
            }
            else
            {
                Console.WriteLine("You already have an item in your inventory.");
            }
        }

        public void ShowInventory()
        {
            if (string.IsNullOrEmpty(Inventory))
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine($"Your inventory contains: {Inventory}");
            }
        }
    }
}
