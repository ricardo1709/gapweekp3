using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Swamp : Location
    {
        public Swamp(string name)
            : base(name, null)
        {

        }

        public override void Description(ref Map map)
        {
            Console.WriteLine("You are standing in a swamp.");
        }
    }
}
