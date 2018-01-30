using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TextAdventureCS.Blockades;
using TextAdventureCS.Locations;

namespace TextAdventureCS
{
    class Room
    {
        private int width;
        private int height;
        private string name;
        private Blockade[,,] blockades;
        private Objects[,] items;
        private bool isEnclosed;

        private string discription;

        public Room(string name, int width, int height)
        {
            this.name = name;
            this.height = height;
            this.width = width;
            this.blockades = new Blockade[width, height, 4];
            this.items = new Objects[width, height];
        }

        public void AddItem(Objects item, int x, int y)
        {
            this.items[x, y] = item;
        }

        public void SetBlockage(Blockade blockade, int x, int y)
        {
            this.blockades[x, y, blockade.GetDirection()] = blockade;
        }

        public void SetDiscription(string discription)
        {
            this.discription = discription;
        }

        public void AddLocations(ref Map map, int x, int y)
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    Blockade[] blockades = new Blockade[4];
                    // North Wall
                    if (this.blockades[i,j,0] != null)
                    {
                        blockades[0] = this.blockades[i, j, 0];
                    }
                    else if (j == 0 && isEnclosed)
                        blockades[0] = new Wall("wall", true, 0);
                    else
                        blockades[0] = new None("none", false, 0);

                    // East Wall
                    if (this.blockades[i, j, 1] != null)
                    {
                        blockades[1] = this.blockades[i, j, 1];
                    }
                    else if (i == width - 1 && isEnclosed)
                        blockades[1] = new Wall("wall", true, 1);
                    else
                        blockades[1] = new None("none", false, 1);

                    // South
                    if (this.blockades[i, j, 2] != null)
                    {
                        blockades[2] = this.blockades[i, j, 2];
                    }
                    else if (j == this.height - 1 && isEnclosed)
                        blockades[2] = new Wall("wall", true, 2);
                    else
                        blockades[2] = new None("none", false, 2);

                    // West
                    if (this.blockades[i, j, 3] != null)
                    {
                        blockades[3] = this.blockades[i, j, 0];
                    }
                    else if (i == 0 && isEnclosed)
                        blockades[3] = new Wall("wall", true, 3);
                    else
                        blockades[3] = new None("none", false, 3);

                    Location location = new TempleRoom(this.name, blockades, discription);
                    if(this.items[i,j] != null)
                    location.GetItems().Add(this.items[i,j].GetName(), this.items[i,j]);
                    map.AddLocation(location, i + x, j + y);

                }
            }
        }

        public void SetEnclosed(bool isEnclosed)
        {
            this.isEnclosed = isEnclosed;
        }
    }
}
