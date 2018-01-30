using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Blockades
{
    class None : Blockade
    {
        public None(string name, bool isSolid, int direction) : base(name, isSolid, direction)
        {

        }

        public override bool CanGetDiscription()
        {
            return false;
        }

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
            throw new NotImplementedException();
        }
    }
}
