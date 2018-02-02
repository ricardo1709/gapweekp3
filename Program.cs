using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using TextAdventureCS.Blockades;
using TextAdventureCS.Items;
using TextAdventureCS.Actors;


// Originally made by Sietse Dijks
// Releasedate: 18-01-2014
// Current version: 1.5
// Last changes by: Michiel Pot and Alex van Pelt
// Change Date: 09-01-2015

namespace TextAdventureCS
{
    class Program
    {
        // Define the directions available to the player.
        // Refactored by Michiel and Alex
        const string MOVE_NORTH = "Go North";
        const string MOVE_WEST = "Go West";
        const string MOVE_SOUTH = "Go South";
        const string MOVE_EAST = "Go East";
        
        // Cluster the directions for validation purposes.
        // Refactored by Michiel and Alex
        static List<string> validDirections = new List<string> {
            MOVE_NORTH, 
            MOVE_WEST, 
            MOVE_SOUTH, 
            MOVE_EAST        
        };

        // Refactored by Michiel and Alex
        const string ACTION_SEARCH = "Search";
        const string ACTION_FIGHT = "Fight";
        const string ACTION_RUN = "Run";
        const string ACTION_QUIT = "Exit";

        const string ACTION_INTERACT_NORTH = "Interact North";
        const string ACTION_INTERACT_EAST = "Interact East";
        const string ACTION_INTERACT_SOUTH = "Interact South";
        const string ACTION_INTERACT_WEST = "Interact West";

        const string ACTION_DISCRIPTION_NORTH = "Discription North";
        const string ACTION_DISCRIPTION_EAST = "Discription East";
        const string ACTION_DISCRIPTION_SOUTH = "Discription South";
        const string ACTION_DISCRIPTION_WEST = "Discription West";

        static void Main(string[] args)
        {
            // General initializations to prevent magic numbers
            int mapwidth = 11;
            int mapheight = 11;
            int xstartpos = 1;
            int ystartpos = 1;
            // Welcome the player

            Program.PrintLine(100, "Welcome to a textbased adventure");
            Program.PrintLine(100, "Before you can start your journey, you will have to enter your name.");

            string name = null;
            string input = null;

            // Check for the correct name
            // Refactored from do - while to improve readability by Michiel and Alex
            while (input != "Y")
            {
                if (input == null || input == "N")
                {
                    Program.PrintLine(100, "Please enter your name and press enter:");
                    name = Console.ReadLine();
                }

                Program.PrintLine(100, "Your name is {0}", name);
                Program.PrintLine(100, "Is this correct? (y/n)");
                input = Console.ReadLine();
                input = input.ToUpper();
            }

            // Let the player choose between different types 
            int choice = 0;
            string userInput;

            Player player = null;
            do
            {
                do
                {
                    Program.PrintLine(100, "Which character would you like too be?");
                    Program.PrintLine(100,  "1. Investigator");
                    Program.PrintLine(100,  "2. Soldier");
                    userInput = Console.ReadLine();
                } while (!int.TryParse(userInput, out choice) || choice <= 0 || choice > 2);

                switch (choice)
                {
                    case 1:

                        player = new Investigator(name, 100);
                        break;
                    case 2:
                        player = new Soldier(name, 200);
                        break;
                    case 3:
                    default:
                        break;
                }

            } while (player == null);


            // Make the player


            //Welcome the player

#if !DEBUG
                Welcome(ref player);
#endif

#if DEBUG
            player.PickupItem(new PowerStone("powerstone", true));
              player.PickupItem(new Key("door 2", true));
              player.PickupItem(new Key("door 3", true));
              player.PickupItem(new Key("door 4", true));
              player.PickupItem(new Key("door 5", true));
              player.PickupItem(new Key("door 6", true));
            #endif
            // Initialize the map
            Map map = new Map(mapwidth, mapheight, xstartpos, ystartpos);
            // Put the locations with their items on the map
            InitMap(ref map);
            // Start the game
            Start(ref map, ref player);
            // End the program
            Quit();
        }

        static void Welcome(ref Player player)
        {
            Console.Clear();

            Program.PrintLine( 100, "Welcome to the world of Radius");
            Program.PrintLine( 100, "Storyline: You are a big fan of strawberries, your life goal is to eat as many stawberries as possible..");
            Program.PrintLine( 100, "You heard that there is an temple in the middle of the \nRadius forest. In that temple is a box with magic stawberries");
            Program.PrintLine(100, "These magic strawberries are special.. if you eat one a new one will spawn back into the box.");
            Program.PrintLine(100, "That means.. YOU HAVE AN UNLIMITED SUPPLY OF STRAWBERRIES!");
            Program.PrintLine(100, "But first you have to find that box.. \ngood luck");            
            Program.PrintLine(10, player.GetName());
            Console.WriteLine("Ready? press enter...");
            Console.ReadKey();
            Console.Clear();

            // Added newline to improve readability.
            

            player.ShowInventory();

            Program.PrintLine( 100, "You're excited to go into the temple!");
            Program.PrintLine( 100, "But scared too.. but you just want that magic box!");
            Program.PrintLine( 100, "You prepaired yourself for the worst.. monsters.. traps.. You have no idea what too expect.");
            Program.PrintLine( 100, "Press a key to continue..");

            Console.ReadKey();
        }

        static void InitMap(ref Map map)
        {
            // Add locations with their coordinates to this list.
            /*Forrest forrest = new Forrest("Black Forrest");
            map.AddLocation(forrest, 0, 2);
            Cliff cliff = new Cliff("Rockface");
            map.AddLocation(cliff, 0, 3);
            Church church = new Church("Old Chapel");
            map.AddLocation(church, 1, 2);
            Swamp swamp = new Swamp("Bog");
            map.AddLocation(swamp, 0, 1);*/

            Room room = new Room("Starting room", 3, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 1", true, 2, "Discription"), 1, 2);
            room.SetBlockage(new WallDiscription("", true, 0, ""), 0, 0);
            room.AddItem(new Key("door 1", true), 1, 1);
            room.SetDiscription("{0}. This room will start whit helping you to play.");
            room.AddLocations(ref map, 0, 0);

            room = new Room("start", 6, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 1", true, 0, "Discription"), 1, 0);
            room.SetBlockage(new Door("door 2", true, 2, "Discription: Wow, this is impressive.. but it is creepy too, let's start this adventure!"), 1, 2);
            room.SetBlockage(new Door("door 3", true, 2, "Discription: Pff, i hope this is the last room, atleast the room is called end. So i guess this is the end."), 1, 2);
            room.SetBlockage(new Door("door 4", true, 0, "Discription: ehm.. That other room looked creepy, but this is even worse! why did i ever start this.."), 4, 0);
            room.SetBlockage(new Door("door 3", true, 2, "Discription: Pff, i hope this is the last room, atleast the room is called end. So i guess this is the end."), 4, 2);
            room.SetBlockage(new Door("door 6", true, 1, "Discription: brrr it looks creepy in here.. I better watch out for monsters or traps.."), 5, 1);
            //room.SetBlockage(new Door("door 6", true, 3, "Discription: brrr it looks creepy in here.. I better watch out for monsters or traps.."), 0, 1)
            room.AddItem(new Key("door 2", true), 2, 2);
            room.SetDiscription("{0} .You walk into a big empty room with three doors.\nWitch one do you choose....");
            room.AddLocations(ref map, 0, 3);

            room = new Room("", 3, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 2", true, 2, "Discription: Wow, this is impressive.. but it is creepy too, let's start this adventure!"), 1, 2);
            room.SetDiscription("Wow, this is impressive.. but it is creepy too, let's start this adventure!");
            room.AddLocations(ref map, 0, 6);

            room = new Room("Danger 2.0", 3, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 3", true, 0, "Discription: Wow, this is impressive.. but it is creepy too, let's start this adventure!"), 1, 0);
            room.SetDiscription("This is the {0} room!\n");
            room.SetEnemy(new StoneEnemy("stone enemy", 30), 0, 1);
            room.SetEnemy(new StoneEnemy("stone enemy", 30), 2, 1);
            room.AddLocations(ref map, 3, 6);

            room = new Room("Riddle", 3, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 5", true, 0, "Discription: Wow! what is this?! there are riddles everywhere!"), 1, 0);
            room.SetDiscription("This is the {0} room 2\n");
            room.AddLocations(ref map, 6, 6);

            room = new Room("Danger!", 3, 3);
            room.SetEnclosed(true);
            room.SetBlockage(new Door("door 6", true, 3, "Discription: brrr it looks creepy in here.. I better watch out for monsters or traps.."), 0, 1);
            room.SetDiscription("This is the {0} room \n");
            room.AddLocations(ref map, 6, 3);

            map.SetRoom(" ");
        }

        static void Start(ref Map map, ref Player player)
        {
            List<string> menuItems = new List<string>();

            int choice = 0;
            Random rdm = new Random();


            // Refactored by Michiel and Alex
            do
            {

                Console.Clear();
                
                map.GetLocation().Description(ref map);
                if (menuItems.Count != 0) {
                    if (menuItems[choice].StartsWith(ACTION_DISCRIPTION_NORTH))
                    {
                        Program.PrintLine(100, map.GetLocation().GetBlockage(0).GetDiscription(ref map));
                    }
                    else if (menuItems[choice].StartsWith(ACTION_DISCRIPTION_EAST))
                    {
                        Program.PrintLine(100, map.GetLocation().GetBlockage(1).GetDiscription(ref map));
                    }
                    else if (menuItems[choice].StartsWith(ACTION_DISCRIPTION_SOUTH))
                    {
                        Program.PrintLine(100, map.GetLocation().GetBlockage(2).GetDiscription(ref map));
                    }
                    else if (menuItems[choice].StartsWith(ACTION_DISCRIPTION_WEST))
                    {
                        Program.PrintLine(100, map.GetLocation().GetBlockage(3).GetDiscription(ref map));
                    }
                }
                choice = ShowMenu(map, ref menuItems);

                if ( choice != menuItems.Count() )
                {
                    if ( validDirections.Contains( menuItems[choice] ) )
                    {
                        map.Move( menuItems[choice] );
                    }

                    if (menuItems[choice].StartsWith(ACTION_INTERACT_NORTH))
                    {
                        map.GetLocation().GetBlockage(0).OnPlayerInteraction(ref player, ref map);
                    }
                    else if (menuItems[choice].StartsWith(ACTION_INTERACT_EAST))
                    {
                        map.GetLocation().GetBlockage(1).OnPlayerInteraction(ref player, ref map);
                    }
                    else if (menuItems[choice].StartsWith(ACTION_INTERACT_SOUTH))
                    {
                        map.GetLocation().GetBlockage(2).OnPlayerInteraction(ref player, ref map);
                    }
                    else if (menuItems[choice].StartsWith(ACTION_INTERACT_WEST))
                    {
                        map.GetLocation().GetBlockage(3).OnPlayerInteraction(ref player, ref map);
                    }
                    
                    switch ( menuItems[choice] )
                    {
                        case ACTION_SEARCH:
                            foreach(Objects item in map.GetLocation().GetItems().Values)
                            {
                                player.PickupItem(item);
                            }
                                
                        break;

                        case ACTION_FIGHT:
                            map.GetLocation().GetEnemy().TakeHit(rdm.Next(10, 20));
                            if (map.GetLocation().GetEnemy().GetHealth() > 0)
                            {
                                player.TakeHit(rdm.Next(5, 20));
                                if (player.GetHealth() <= 0)
                                {
                                    Console.ReadLine();
                                    Quit();
                                }
                            }
                            else
                            {
                                Program.PrintLine(100, "You have won from you enemy");
                                if (!map.GetLocation().GetItems().ContainsKey(map.GetLocation().GetEnemy().Loot().GetName()))
                                {
                                    map.GetLocation().GetItems().Add(map.GetLocation().GetEnemy().Loot().GetName(), map.GetLocation().GetEnemy().Loot());
                                }
                               
                                map.GetLocation().SetEnemy(null);
                            }
                                
                        break;

                        case ACTION_RUN:
                            Program.PrintLine(100, "You shouldn't have runned away from your enemy");
                            Console.ReadLine();
                            Quit();
                        break;
                    }
                }
            } 
            // When the choice is equal to the total item it means exit has been chosen.
            while ( choice < menuItems.Count() - 1);
        }

        // This Method builds the menu
        static int ShowMenu(Map map, ref List<string> menu)
        {
            int choice;
            string input;

            menu.Clear();
            ShowDirections(map, ref menu);
            ShowInteractions(map, ref menu);

            if (map.GetLocation().CheckForItems())
            {
                bool acquirableitems = false;
                Dictionary<string, Objects> list = map.GetLocation().GetItems();
                Objects[] obj = list.Values.ToArray();
                for (int i = 0; i < obj.Count(); i++)
                {
                    if (obj[i].GetAcquirable())
                        acquirableitems = true;
                }
                if(acquirableitems)
                    menu.Add( ACTION_SEARCH );
            }
            if (map.GetLocation().HasEnemy())
            {
                menu.Clear();
                menu.Add( ACTION_FIGHT );
                menu.Add( ACTION_RUN );
            }
            

            menu.Add( ACTION_QUIT );

            do
            {
                for (int i = 0; i < menu.Count(); i++)
                {
                    Program.PrintLine( 0,"{0} - {1}", i + 1, menu[i]);
                }
                Program.PrintLine( 50,"Please enter your choice: 1 - {0}" ,menu.Count());
                input = Console.ReadLine();
            } while (!int.TryParse(input, out choice) || (choice > menu.Count() || choice < 0));

            //return choice;
            return ( choice - 1 );
        }

        static void ShowDirections(Map map, ref List<string> items)
        {
            map.AllowedDirections();

            if (map.GetNorth() == 1)
                items.Add( MOVE_NORTH );
            if (map.GetEast() == 1)
                items.Add( MOVE_EAST );
            if (map.GetSouth() == 1)
                items.Add( MOVE_SOUTH );
            if (map.GetWest() == 1)
                items.Add( MOVE_WEST );
        }

        static void ShowInteractions(Map map, ref List<string> items)
        {
            Location location = map.GetLocation();
            if (location.GetBlockage(0).CanPlayerInteraction())
                items.Add(ACTION_INTERACT_NORTH + " " + location.GetBlockage(0).GetName());
            if (location.GetBlockage(1).CanPlayerInteraction())
                items.Add(ACTION_INTERACT_EAST + " " + location.GetBlockage(1).GetName());
            if (location.GetBlockage(2).CanPlayerInteraction())
                items.Add(ACTION_INTERACT_SOUTH + " " + location.GetBlockage(2).GetName());
            if (location.GetBlockage(3).CanPlayerInteraction())
                items.Add(ACTION_INTERACT_WEST + " " + location.GetBlockage(3).GetName());

            if (location.GetBlockage(0).CanGetDiscription())
                items.Add(ACTION_DISCRIPTION_NORTH + " " + location.GetBlockage(0).GetName());
            if (location.GetBlockage(1).CanGetDiscription())
                items.Add(ACTION_DISCRIPTION_EAST + " " + location.GetBlockage(1).GetName());
            if (location.GetBlockage(2).CanGetDiscription())
                items.Add(ACTION_DISCRIPTION_SOUTH + " " + location.GetBlockage(2).GetName());
            if (location.GetBlockage(3).CanGetDiscription())
                items.Add(ACTION_DISCRIPTION_WEST + " " + location.GetBlockage(3).GetName());
        }

        static void Quit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing and have a nice day!");
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }

        public static void PrintLine(int timemilli, string msg, params object[] par)
        {
            PrintLine(string.Format(msg, par), timemilli, true, 0, 64);
        }

        public static void PrintLine(string msg, int timemilli, bool endNewLine, int startPosX, int endPosX)
        {
            Console.CursorVisible = true;
            string[] words = msg.Split(' ');
            for (int i=0;i<words.Count(); i++)
            {
                if (Console.CursorLeft + 1 + words[i].Count()  >= endPosX)
                {
                    Console.CursorLeft = startPosX;
                    Console.CursorTop = Console.CursorTop + 1;
                }
                else
                {
                    if (i != words.Count() && i != 0)
                        Console.Write(" ");
                }
                
                foreach (char c in words[i])
                {
                    DateTime time = System.DateTime.Now;
                    
                    if (c != '\n')
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.CursorLeft = startPosX;
                        Console.CursorTop = Console.CursorTop + 1;
                    }
                    

                    int end = System.DateTime.Now.Millisecond - time.Millisecond;
                    if (timemilli - end > 0){
                        System.Threading.Thread.Sleep((int)(timemilli - end));
                    }
                }

            }
            
            if (endNewLine)
            {
                Console.Write("\n");
            }
            Console.CursorVisible = false;
        }
    }
}