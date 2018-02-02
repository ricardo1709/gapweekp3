using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TextAdventureCS;

namespace TextAdventureCS.Blockades
{
    class Door : Blockade
    {

        private string discription;

        public Door(string name, bool isSolid, int direction, string discription) : base(name, isSolid, direction)
        {
            this.discription = discription;
        }

        public override bool CanGetDiscription()
        {
            return true;
        }

        public override bool CanPlayerInteraction()
        {
            return this.isSolid;
        }

        public override string GetDiscription(ref Map map)
        {
            return this.discription;
        }

        public override void OnPlayerInteraction(ref Player player, ref Map map)
        {
            if (player.HasObject("Key of " + name) && player.HasObject("powerstone"))
            {
                player.UseItem("Key of " + name);
                this.isSolid = false;
                Door door;
                switch (direction)
                {
                    case 0:
                        if (map.GetLocation(0, -1) == null)
                            return;
                        door = (Door) map.GetLocation(0, -1).GetBlockage(2);
                        break;
                    case 1:
                        if (map.GetLocation(1, 0) == null)
                            return;
                        door = (Door) map.GetLocation(1, 0).GetBlockage(3);
                        break;
                    case 2:
                        if (map.GetLocation(0, 1) == null)
                            return;
                        door = (Door) map.GetLocation(0, 1).GetBlockage(0);
                        break;
                    case 3:
                        if (map.GetLocation(-1, 0) == null)
                            return;
                        door = (Door) map.GetLocation(-1, 0).GetBlockage(1);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("The Direction is out of range it should be between 0 and 3");
                }
                
                door.isSolid = false;
                
            }
            else
            {
            }

        }
    }
}
