using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy
{
    public class EmptyGeneratorStrategy : IStrategy
    {
        public Dungeon Generate(int w, int h)
        {
            return new Dungeon(w, h);
        }
    }
}
