using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS.Actors
{
    class Soldier : Player
    {
        public Soldier(string name, int maxHealth) : base(name, maxHealth)
        {

        }

        public override void TakeHit(int damage)
        {
            health -= damage * 9 / 10;
        }
    }
}
