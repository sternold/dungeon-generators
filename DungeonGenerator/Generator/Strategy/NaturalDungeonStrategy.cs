using System;
using Game.Models;

namespace Game.Generator.Strategy
{
    public class NaturalDungeonStrategy : IStrategy
    {
        private readonly Random _rand = new Random();
        
        private readonly int _iterations;
        
        public NaturalDungeonStrategy(int iterations = 1024)
        {
            _iterations = iterations;
        }

        public Dungeon Generate(int w, int h)
        {
            var dungeon = new Dungeon(w, h).Fill('#');

            var x = _rand.Next(0, w);
            var y = _rand.Next(0, h);
            for(var i = 0; i < _iterations; i++)
            {
                if (dungeon[x, y] == '.') 
                    i--;
                
                dungeon[x, y] = '.';
                switch (_rand.Next(4))
                {
                    case 0:
                        if (--x < 0)
                            x++;
                        break;
                    case 1:
                        if (++x >= w)
                            x--;
                        break;
                    case 2:
                        if (--y < 0)
                            y++;
                        break;
                    case 3:
                        if (++y >= h)
                            y--;
                        break;
                    default:
                        i--;
                        break;
                }
            }

            return dungeon;
        }
    }
}
