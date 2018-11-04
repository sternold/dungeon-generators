using Game.Models;

namespace Game.Generator.Strategy
{
    public class EmptyGeneratorStrategy : IStrategy
    {
        private readonly char _fill;

        public EmptyGeneratorStrategy(char fill = ' ')
        {
            _fill = fill;
        }
        
        
        public Dungeon Generate(int w, int h)
        {
            return new Dungeon(w, h).Fill(_fill);
        }
    }
}
