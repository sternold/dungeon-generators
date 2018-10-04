using Game.Generator.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator
{
    public class DungeonGenerator
    {
        private IStrategy _strategy;

        public DungeonGenerator() : this(new EmptyGeneratorStrategy())
        {
        }

        public DungeonGenerator(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetGenerator(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public Dungeon Generate(int w, int h)
        {
            return _strategy.Generate(w, h);
        }
    }
}
