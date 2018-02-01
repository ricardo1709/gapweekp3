using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    abstract class Actor
    {
        protected string name;
        protected int maxHealth;
        protected int health;
        
        public Actor( string name, int maxHealth )
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public abstract void TakeHit(int damage);         

        public string GetName()
        {
            return name;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetHealth()
        {
            return health;
        }

        public abstract Objects Loot();
    }
}
