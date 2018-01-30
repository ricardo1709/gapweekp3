using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    abstract class Blockade
    {
        protected bool isSolid;
        protected string name;
        protected int direction;

        public Blockade(string name, bool isSolid, int direction)
        {
            this.name = name;
            this.isSolid = isSolid;
            this.direction = direction;
        }

        public abstract void OnPlayerInteraction(ref Player player, ref Map map);
        public abstract bool CanPlayerInteraction();

        public bool IsSolid()
        {
            return this.isSolid;
        }

        public int GetDirection()
        {
            return this.direction;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
