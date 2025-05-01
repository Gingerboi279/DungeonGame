using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonExplorer.Game;
using static DungeonExplorer.Player;
using System.Xml.Linq;

namespace DungeonExplorer
{
    public class Monster : Creature, IDamageable
    {
        public Monster(string name, int health) : base(name, health) { }

        public override void Attack(Creature target)
        {
            int damage = new Random().Next(5, 15);
            Console.WriteLine($"{Name} attacks {target.Name}, dealing {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}
