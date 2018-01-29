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
                Console.WriteLine("{0} is removed from your inventory",itemName);
                ShowInventory();
                Console.WriteLine("Press a key to continue..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your inventory does not contain an item");
                Console.WriteLine("with the name {0}. Please try again.", itemName);
                Console.WriteLine("Press a key to continue..");
                Console.ReadKey();
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
            Console.WriteLine("There are {0} item(s) in your inventory.", (int)inventory.Count());
            if (inventory.Count() > 0)
            {
                Console.WriteLine("These are:");
                foreach (var item in inventory)
                {
                    Console.WriteLine(item.Value);
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
                Console.WriteLine("You took too much damage. You fall to the ground.");
                Console.WriteLine("As you move towards the light, the last thing going through");
                Console.WriteLine("your mind is: 'This was a great adventure. Too bad it had");
                Console.WriteLine("to end like this.' And then it is all over...");
                Console.WriteLine("Press a key to continu...");
                Console.ReadKey();
            }
            else
            {
                health -= damage;
                Console.Clear();
                Console.WriteLine("You took {0} points of damage.", damage);
                Console.WriteLine("You now have {0} HP left.", health);

                if (health < (maxHealth >> 2))
                {
                    Console.WriteLine("You took some serious hits and you are bleeding.");
                    Console.WriteLine("You start to feel weak and desperately need some");
                    Console.WriteLine("medical attention.");
                }
                else if (health < (maxHealth >> 1))
                {
                    Console.WriteLine("You took some hits. You have some scratches and some cuts.");
                    Console.WriteLine("Your body starts to ache and you have to be careful.");
                }
                else if (health < (maxHealth - (maxHealth >> 2)))
                {
                    Console.WriteLine("You have a few scratches, nothing to worry about yet.");
                }
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
            }
        }
    }
}
