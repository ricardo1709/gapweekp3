using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Player : Actor
    {
        private Dictionary<string, Objects> inventory;

        public Player(string name, int maxHealth)
            : base(name, maxHealth)
        {
            inventory = new Dictionary<string, Objects>();
        }

        public void DropItem(string itemName)
        {
            if (HasObject(itemName))
            {
                inventory.Remove(itemName);
                Program.PrintLine( 100,string.Format("{0} is removed from your inventory",itemName));
                ShowInventory();
                Program.PrintLine( 50,"Press a key to continue..");
                Console.ReadKey();
            }
            else
            {
                Program.PrintLine( 100, "Your inventory does not contain an item");
                Program.PrintLine( 100,"with the name {0}. Please try again.", itemName);
                Program.PrintLine( 50,"Press a key to continue..");
                Console.ReadKey();
            }
        }

        public void UseItem(string itemName)
        {
            if (HasObject(itemName))
            {
                inventory.Remove(itemName);
                Program.PrintLine  (75,string.Format("{0} has been used.\n{0} is removed from your inventory", itemName));
            }
        }

        public void PickupItem(Objects obj)
        {
            // Add an if-statement here when you want to have a maximum number of items
            inventory.Add(obj.GetName(), obj);
            obj.SetIsAcquirable(false);
        }

        public void ShowInventory()
        {
            Program.PrintLine( 100, "There are {0} item(s) in your inventory.",inventory.Count());
            if (inventory.Count() > 0)
            {
                Program.PrintLine( 100,"These are:");
                foreach (var item in inventory)
                {
                    Program.PrintLine(50, item.Value.GetName());
                }
            }
        }

        public bool HasObject(string name)
        {
            if (inventory.ContainsKey(name))
                return true;
            else
                return false;
        }

        public override void TakeHit( int damage )
        {
            if (health - damage < 0)
            {
                Console.Clear();
                Program.PrintLine( 100,"You took too much damage. You fall to the ground.");
                Program.PrintLine( 100,"As you move towards the light, the last thing going through");
                Program.PrintLine( 100,"your mind is: 'This was a great adventure. Too bad it had");
                Program.PrintLine( 100,"to end like this.' And then it is all over...");
                Program.PrintLine ( 50,"Press a key to continue...");
                Console.ReadKey();
            }
            else
            {
                health -= damage;
                Console.Clear();
                Program.PrintLine( 80,  "You took {0} points of damage.", damage);
                Program.PrintLine( 80,  "You now have {0} HP left.", health);

                if (health < (maxHealth >> 2))
                {
                    Program.PrintLine( 100,"You took some serious hits and you are bleeding.");
                    Program.PrintLine( 100, "You start to feel weak and desperately need some");
                    Program.PrintLine( 100, "medical attention.");
                }
                else if (health < (maxHealth >> 1))
                {
                    Program.PrintLine( 100, "You took some hits. You have some scratches and some cuts.");
                    Program.PrintLine( 100, "Your body starts to ache and you have to be careful.");
                }
                else if (health < (maxHealth - (maxHealth >> 2)))
                {
                    Program.PrintLine( 100,"You have a few scratches, nothing to worry about yet.");
                }
                Program.PrintLine  (50,"Press a key to continue");
                Console.ReadKey();
            }
        }
    }
}
