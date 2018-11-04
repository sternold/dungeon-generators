using Game.Generator.Strategy.Models;
using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.Generator.Strategy
{
    public class SimpleGeneratorStrategy : IStrategy
    {
        private readonly Random _rand = new Random();
        
        private readonly int _scale;
        private readonly int _roomCount;

        public SimpleGeneratorStrategy(int roomCount = 8, int scale = 16)
        {
            _roomCount = roomCount;
            _scale = scale;

        }

        public Dungeon Generate(int w, int h)
        {
            var dungeon = new Dungeon(w, h).Fill('#');

            var rooms = new List<Rectangle>();
            for (var i = 0; i < _roomCount; i++)
            {
                var room = new Rectangle(
                    _rand.Next(0, w - _scale),
                    _rand.Next(0, h - _scale),
                    _rand.Next(4, _scale),
                    _rand.Next(4, _scale)
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
                if (_rand.Next(0, 1) == 0)
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