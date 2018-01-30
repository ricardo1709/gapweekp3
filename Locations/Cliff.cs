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

        public override void Description(ref Map map)
        {
            Program.PrintLine( 100,"You are standing in front of a cliff.");
            Program.PrintLine( 100,"This is a dead end. You can only go back");
        }
    }
}
