﻿using System;

namespace Game.Generator.Strategy
{
    public class BSPGeneratorStrategy : IStrategy
    {
        private readonly int _minimumSize;

        public BSPGeneratorStrategy(int minimumSize)
        {
            this._minimumSize = minimumSize;
        }

        public Dungeon Generate(int w, int h)
        {
            throw new NotImplementedException();
        }
    }
}
