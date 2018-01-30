using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Church : Location
    {
        public Church(string name)
            : base(name, null)
        {

        }

        public override void Description()
        {
            Program.PrintLine( 50,"You are standing in front of a church.");
        }
    }
}
