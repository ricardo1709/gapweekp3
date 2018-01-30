using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Diamond : Objects
    {
        public Diamond(string name, bool acquirable)
            : base(name, acquirable)
        {
        }

        override protected void Description()
        {
            Program.PrintLine(50,"You see a shining Diamond lying on the ground.");
        }
    }
}
