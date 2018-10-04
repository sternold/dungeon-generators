using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy
{
    class NaturalDungeonStrategy : IStrategy
    {
        private readonly int iterations;

        public NaturalDungeonStrategy(int iterations)
        {
            this.iterations = iterations;
        }

        public Dungeon Generate(int w, int h)
        {
            var rand = new Random();
            var dungeon = new Dungeon(w, h);

            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    dungeon[x, y] = '#';

            int prevX = rand.Next(0, w);
            int prevY = rand.Next(0, h);
            for(int i = 0; i < iterations; i++)
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
