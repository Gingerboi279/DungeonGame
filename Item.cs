using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonExplorer.Player;

namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }

        protected Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
    }
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} uses {Name}, increasing attack power by {Damage}!");
        }
    }
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"{player.Name} drinks {Name}, restoring {HealAmount} health. Current health: {player.Health}");
        }
    }
}
