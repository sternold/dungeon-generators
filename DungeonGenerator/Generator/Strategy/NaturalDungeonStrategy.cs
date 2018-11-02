using System;

namespace Game.Generator.Strategy
{
    public class NaturalDungeonStrategy : IStrategy
    {
        private readonly int _iterations;

        public NaturalDungeonStrategy(int iterations)
        {
            _iterations = iterations;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();
            var dungeon = new Dungeon(w, h);

            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    dungeon[x, y] = '#';

            var prevX = rand.Next(0, w);
            var prevY = rand.Next(0, h);
            for(var i = 0; i < _iterations; i++)
            {
                dungeon[prevX, prevY] = '.';
                switch (rand.Next(4))
                {
                    case 0:
                        prevX = prevX - 1 >= 0 ? prevX - 1 : prevX;
                        break;
                    case 1:
                        prevX = prevX + 1 < w ? prevX + 1 : prevX;
                        break;
                    case 2:
                        prevY = prevY - 1 >= 0 ? prevY - 1 : prevY;
                        break;
                    case 3:
                        prevY = prevY + 1 < h ? prevY + 1 : prevY;
                        break;
                }
            }

            return dungeon;
        }
    }
}
