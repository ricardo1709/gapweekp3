using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Forrest : Location
    {
        public Forrest(string name)
            : base(name, null)
        {
            // Add items here
            Diamond dia = new Diamond("Diamond", true);
            items.Add(dia.GetName(), dia);
            // If there is an enemy, set enemy to true
            hasEnemy = true;
        }

        public override void Description(ref Map map)
        {
            // Insert a nice description
            Console.WriteLine("You are standing in a forrest");
        }
    }
}
