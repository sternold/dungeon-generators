using Game.Generator.Strategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy
{
    class SimpleGeneratorStrategy : IStrategy
    {
        private readonly static int SCALE = 12;
        private readonly int rooms_size;

        public SimpleGeneratorStrategy(int rooms_size)
        {
            this.rooms_size = rooms_size;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();

            var dungeon = new Dungeon(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    dungeon[x, y] = '#';

            List<Rectangle> rooms = new List<Rectangle>();
            for(int i = 0; i < rooms_size; i++)
            {
                var room = new Rectangle(
                    rand.Next(0, w-SCALE),
                    rand.Next(0, h-SCALE),
                    rand.Next(4, SCALE),
                    rand.Next(4, SCALE)
                    );

                bool skip = false;
                foreach (var prev in rooms)
                {
                    if (room.Intersects(prev))
                    {
                        i--;
                        skip = true;
                        break;
                    }
                }
                if (skip)
                    continue;
                rooms.Add(room);

                for (int x = room.X1; x < room.X2; x++)
                    for (int y = room.Y1; y < room.Y2; y++)
                        dungeon[x, y] = '.';
            }

            return dungeon;
        }
    }
}
