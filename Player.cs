using System;
using System.Collections.Generic;
using static DungeonExplorer.Game;
using static DungeonExplorer.Player;
using System.Xml.Linq;
using System.Linq;
using System.Data.Common;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        public Inventory Inventory { get; private set; }

        public Player(string name) : base(name, 100)
        {
            Inventory = new Inventory();
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a basic attack.");
            target.TakeDamage(10);
        }
    }
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item.Name} to inventory.");
        }

        public void ShowInventory()
        {
            if (!items.Any())
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.WriteLine("Inventory:");
            items.ForEach(i => Console.WriteLine($"- {i.Name}"));
        }

        public void UseItem(string name, Player player)
        {
            try
            {
                var item = items.First(i => i.Name.ToLower() == name.ToLower());
                item.Use(player);
                items.Remove(item);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void ShowWeaponsOnly()
        {
            //Here we see an example of using LINQs to filter items in the inentory to only weapons
            var weapons = items.OfType<Weapon>().ToList();
            if (!weapons.Any())
            {
                Console.WriteLine("No weapons found in inventory.");
                return;
            }
            weapons.ForEach(w => Console.WriteLine($"Weapon: {w.Name}, Damage: {w.Damage}"));
        }
    }
}
