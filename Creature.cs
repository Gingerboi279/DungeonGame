using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void Attack(Creature target);

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage. Health now: {Health}");
        }
    }
}
