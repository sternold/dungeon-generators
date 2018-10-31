using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy
{
    class SimpleGeneratorStrategy : IStrategy
    {
        private static int MIN_WIDTH = 4;
        private static int MIN_HEIGHT = 4;
        private static int MAX_WIDTH = 12;
        private static int MAX_HEIGHT = 12;

        private abstract class Shape
        {
            public int X1 { get; protected set; }
            public int Y1 { get; protected set; }
            public int X2 { get; protected set; }
            public int Y2 { get; protected set; }


            public int CenterX => (X1 + X2) / 2;
            public int CenterY => (Y1 + Y2) / 2;
            public int Width => X2 - X1;
            public int Height => Y2 - Y1;

            public Shape(int x, int y, int w, int h)
            {
                X1 = x;
                Y1 = y;
                X2 = x + w;
                Y2 = y + h;
            }

            public bool Intersects(Shape s)
            {
                return (X2 >= s.X1 && X1 <= s.X2) || (Y2 >= s.Y1 && Y1 <= s.Y2);
            }

            public void Draw(Dungeon d)
            {
                for (int x = X1; x < X2; x++)
                    for (int y = Y1; y < Y2; y++)
                        d[x, y] = '.';
            }
        }

        private class Room : Shape
        {
            public Room(int x, int y, int w, int h) : base(x, y, w, h)
            {

            }
        }

        private class VHallway : Shape
        {
            public VHallway(int x, int y, int h) : base(x, y, 1, h)
            {

            }
        }

        private class HHallway : Shape
        {
            public HHallway(int x, int y, int w) : base(x, y, w, 1)
            {

            }
        }

        private readonly int rooms;

        public SimpleGeneratorStrategy(int rooms)
        {
            this.rooms = rooms;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();

            var dungeon = new Dungeon(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    dungeon[x, y] = '#';

            Room prev = null;
            for(int i = 0; i < rooms; i++)
            {
                Room room = new Room(
                    rand.Next(0, w-MAX_WIDTH), 
                    rand.Next(0, h-MAX_HEIGHT), 
                    rand.Next(MIN_WIDTH, MAX_WIDTH), 
                    rand.Next(MIN_HEIGHT, MAX_HEIGHT)
                    );
                if (prev != null)
                {
                    if (prev.Intersects(room))
                    {
                        i--;
                        continue;
                    }

                    Shape vhallway = null;
                    Shape hhallway = null;
                    if (rand.Next(1) == 0)
                    {
                        hhallway = new HHallway(room.CenterX, prev.CenterY, prev.Width);
                        vhallway = new VHallway();
                    }
                    else
                    {
                        vhallway = new VHallway();
                        hhallway = new HHallway();
                    }
                    vhallway.Draw(dungeon);
                    hhallway.Draw(dungeon);
                }


                room.Draw(dungeon);
                prev = room;
            }

            return dungeon;
        }
    }
}
