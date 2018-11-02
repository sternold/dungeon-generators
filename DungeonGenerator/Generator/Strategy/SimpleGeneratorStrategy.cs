using Game.Generator.Strategy.Models;
using System;
using System.Collections.Generic;

namespace Game.Generator.Strategy
{
    public class SimpleGeneratorStrategy : IStrategy
    {
        private const int Scale = 12;
        private readonly int _roomsSize;

        public SimpleGeneratorStrategy(int roomsSize)
        {
            _roomsSize = roomsSize;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();

            var dungeon = new Dungeon(w, h);
            for (var x = 0; x < w; x++)
            for (var y = 0; y < h; y++)
                dungeon[x, y] = '#';

            var rooms = new List<Rectangle>();
            for (var i = 0; i < _roomsSize; i++)
            {
                var room = new Rectangle(
                    rand.Next(0, w - Scale),
                    rand.Next(0, h - Scale),
                    rand.Next(4, Scale),
                    rand.Next(4, Scale)
                );

                var skip = false;
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


                if (i <= 0) continue;

                var newCenter = room.Center;
                var oldCenter = rooms[i - 1].Center;
                if (rand.Next(0, 1) == 0)
                {
                    for (var x = Math.Min(oldCenter.X, newCenter.X); x < Math.Max(oldCenter.X, newCenter.X); x++)
                        dungeon[x, newCenter.Y] = '.';
                    for (var y = Math.Min(oldCenter.Y, newCenter.Y); y < Math.Max(oldCenter.Y, newCenter.Y); y++)
                        dungeon[oldCenter.X, y] = '.';
                }
                else
                {
                    for (var x = Math.Min(oldCenter.X, newCenter.X); x < Math.Max(oldCenter.X, newCenter.X); x++)
                        dungeon[x, oldCenter.Y] = '.';
                    for (var y = Math.Min(oldCenter.Y, newCenter.Y); y < Math.Max(oldCenter.Y, newCenter.Y); y++)
                        dungeon[newCenter.X, y] = '.';
                }
            }


            return dungeon;
        }
    }
}