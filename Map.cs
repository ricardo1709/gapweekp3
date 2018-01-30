using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Map
    {
        private int height;
        private int width;
        private Location[,] map;

        private Position pos;
        private Directions directions;

        private string room;

        private struct Position
        {
            public int Xposition;
            public int Yposition;
        }

        private struct Directions
        {
            public int north;
            public int east;
            public int south;
            public int west;
        }

        public Map(int width, int height, int XStartPos, int YStartPos)
        {
            this.width = width;
            this.height = height;

            map = new Location[this.width, this.height];
            directions = new Directions();
            
            if ((XStartPos < width) && (XStartPos >= 0) && (YStartPos < height) && (YStartPos >= 0))
            {
                pos = new Position() { Xposition = XStartPos, Yposition = YStartPos };
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: Position is outside the map");
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
            }
        }

        public void AddLocation(Location loc, int XPos, int YPos)
        {
            map[XPos, YPos] = loc;
        }

        public void Move( string dir )
        {
            switch (dir)
            {
                case "Go North":
                    pos.Yposition -= 1;
                    break;
                case "Go East":
                    pos.Xposition += 1;
                    break;
                case "Go South":
                    pos.Yposition += 1;
                    break;
                case "Go West":
                    pos.Xposition -= 1;
                    break;
                default:
                    Console.WriteLine("Move() has broken down.");
                    break;
            }
        }

        public void AllowedDirections()
        {
            // if a direction has a value of 1, then the player can go there
            directions.north = 1;
            directions.east = 1;
            directions.south = 1;
            directions.west = 1;

            // Check boundries and if there is a level north in the array
            if (pos.Yposition - 1 < 0)
                directions.north = -1;
            else if (map[pos.Xposition, pos.Yposition - 1] == null)
                directions.north = -1;
            else if (map[pos.Xposition, pos.Yposition].GetBlockage(0).IsSolid())
                directions.north = -1;

            // Check boundries and if there is a level south in the array
            if (pos.Yposition + 1 >= height)
                directions.south = -1;
            else if (map[pos.Xposition, pos.Yposition + 1] == null)
                directions.south = -1;
            else if (map[pos.Xposition, pos.Yposition].GetBlockage(2).IsSolid())
                directions.south = -1;

            // Check boundries and if there is a level east in the array
            if (pos.Xposition + 1 >= width)
                directions.east = -1;
            else if (map[pos.Xposition + 1, pos.Yposition] == null)
                directions.east = -1;
            else if (map[pos.Xposition, pos.Yposition].GetBlockage(1).IsSolid())
                directions.east = -1;

            // Check boundries and if there is a level west in the array
            if (pos.Xposition - 1 < 0)
                directions.west = -1;
            else if (map[pos.Xposition - 1, pos.Yposition] == null)
                directions.west = -1;
            else if (map[pos.Xposition, pos.Yposition].GetBlockage(3).IsSolid())
                directions.west = -1;
        }

        public Location GetLocation()
        {
            return map[pos.Xposition,pos.Yposition];
        }

        public Location GetLocation(int XOfset, int YOfset)
        {
            return map[pos.Xposition + XOfset, pos.Yposition + YOfset];
        }

        public int GetNorth()
        {
            return directions.north;
        }

        public int GetEast()
        {
            return directions.east;
        }

        public int GetSouth()
        {
            return directions.south;
        }

        public int GetWest()
        {
            return directions.west;
        }

        public void SetRoom(string room)
        {
            this.room = room;
        }

        public string GetRoom()
        {
            return this.room;
        }
    }
}
