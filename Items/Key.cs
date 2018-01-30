using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Items
{
    class Key : Objects
    {
        public Key(string name, bool acquirable)
            : base("Key of " + name, acquirable)
        {
        }

        override protected void Description()
        {
            Console.WriteLine("You see a shining Diamond lying on the ground.");
        }
    }
}
