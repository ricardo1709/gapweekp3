using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Locations
{
    class TempleRoom : Location
    {
        private string discription;

        public TempleRoom(string name, Blockade[] blockades, string discription)
            : base(name, blockades)
        {
            this.discription = discription;
        }

        public override void Description(ref Map map)
        {
            int time = 50;
            if (map.GetRoom() == this.name)
            {
                time = 0;
            }
            map.SetRoom(this.name);
            int top = Console.CursorTop;
            Console.CursorTop = 0;
            Console.CursorLeft = 66;
            Program.PrintLine(string.Format(discription, name), time, true, 66, Console.BufferWidth);
            Console.CursorTop = top;
        }
    }
}
