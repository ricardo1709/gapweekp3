using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TextAdventureCS.Actors;
namespace TextAdventureCS.Blockades
{
    class WallDiscription : Blockade
    {
        public WallDiscription(string name, bool isSolid, int direction) : base(name, isSolid, direction)
        {

        }

        public override bool CanGetDiscription()
        {
            return true;
        }

        public override bool CanPlayerInteraction()
        {
            return false;
        }

        public override string GetDiscription(ref Map map)
        {
            int posY = 0;
            int posX = 0;

            switch (this.direction)
            {
                case 0:
                    posY = 1;
                    posX = 0;
                    break;
                case 1:
                    posY = 0;
                    posX = -1;
                    break;
                case 2:
                    posY = -1;
                    posX = 0;
                    break;
                case 3:
                    posY = 0;
                    posX = 1;
                    break;
            }

            map.GetLocation(posX, posY).SetEnemy(new StoneEnemy("stone guard", 10));
            return "When you was reading the text on the wall you read turn around.";
        }

        public override void OnPlayerInteraction(ref Player player, ref Map map)
        {

        }
    }
}
