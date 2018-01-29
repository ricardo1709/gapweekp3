using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Cliff : Location
    {
        public Cliff(string name)
            : base(name, null)
        {
        }

        public override void Description()
        {
            Console.WriteLine("You are standing in front of a cliff.");
            Console.WriteLine("This is a dead end. You can only go back");
        }
    }
}
