using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TextAdventureCS;

namespace TextAdventureCS.Blockades
{
    class Wall : Blockade
    {
        public Wall(string name, bool isSolid, int direction) : base(name, isSolid, direction)
        {

        }

        public override bool CanGetDiscription() => false;

        public override bool CanPlayerInteraction()
        {
            return false;
        }

        public override string GetDiscription(ref Map map)
        {
            throw new NotImplementedException();
        }

        public override void OnPlayerInteraction(ref Player player, ref Map map)
        {
            
        }
    }
}
