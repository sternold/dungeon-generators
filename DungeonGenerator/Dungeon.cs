using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class Dungeon : IEnumerable<char>
    {
        private readonly char[] _tiles;

        public int Width { get; }
        public int Height { get; }

        public char this[int x, int y]
        {
            get => _tiles[(x * Height) + y];
            set => _tiles[(x * Height) + y] = value;
        }

        public Dungeon(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this._tiles = new char[width * height];
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++)
                    yield return this[x, y];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
