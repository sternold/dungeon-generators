using System;

namespace Game.Generator.Strategy
{
    public class BSPGeneratorStrategy : IStrategy
    {
        private readonly int _minimumSize;

        public BSPGeneratorStrategy(int MinimumSize)
        {
            this._minimumSize = MinimumSize;
        }

        public Dungeon Generate(int w, int h)
        {
            throw new NotImplementedException();
        }
    }
}
