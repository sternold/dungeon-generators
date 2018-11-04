using Game.Generator.Strategy;
using Game.Models;

namespace Game.Generator
{
    public class DungeonGenerator
    {
        private IStrategy _strategy;

        public IStrategy Strategy
        {
            set => _strategy = value;
        }

        public DungeonGenerator() : this(new EmptyGeneratorStrategy())
        {
        }

        public DungeonGenerator(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public Dungeon Generate(int w, int h) => _strategy.Generate(w, h);
    }
}
