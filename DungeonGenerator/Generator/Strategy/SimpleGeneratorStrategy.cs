using Game.Generator.Strategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy
{
    public class SimpleGeneratorStrategy : IStrategy
    {
        private const int Scale = 12;
        private readonly int _roomsSize;

        public SimpleGeneratorStrategy(int roomsSize)
        {
            this._roomsSize = roomsSize;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();

            var dungeon = new Dungeon(w, h);
            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    dungeon[x, y] = '#';

            var rooms = new List<Rectangle>();
            for(var i = 0; i < _roomsSize; i++)
            {
                var room = new Rectangle(
                    rand.Next(0, w-Scale),
                    rand.Next(0, h-Scale),
                    rand.Next(4, Scale),
                    rand.Next(4, Scale)
                    );

                bool skip = false;
                foreach (var prev in rooms)
                {
                    if (!room.Intersects(prev)) 
                        continue;
                    i--;
                    skip = true;
                    break;
                }
                if (skip)
                    continue;
                rooms.Add(room);

                for (var x = room.X1; x < room.X2; x++)
                    for (var y = room.Y1; y < room.Y2; y++)
                        dungeon[x, y] = '.';
            }

            return dungeon;
        }
    }
}
