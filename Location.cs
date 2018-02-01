using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    abstract class Location
    {
        protected string name;
        protected Actor Enemy;

        protected Blockade[] blockades = new Blockade[4];

        protected Dictionary<string, Objects> items;

        public Location(string name, Blockade[] blockades)
        {
            this.name = name;
            
            items = new Dictionary<string, Objects>();

            this.blockades = blockades;
        }

        abstract public void Description(ref Map map);

        public virtual string GetName()
        {
            return name;
        }


        public virtual bool HasEnemy()
        {
            return Enemy != null;
        }

        public virtual bool CheckForItems()
        {
            if (items.Count() == 0)
                return false;
            else
                return true;
        }

        public Dictionary<string, Objects> GetItems()
        {
            return items;
        }

        public Blockade GetBlockage(int i)
        {
            return blockades[i];
        }

        public void SetEnemy(Actor actor)
        {
            this.Enemy = actor;
        }

        public Actor GetEnemy()
        {
            return this.Enemy;
        }
    }
}
