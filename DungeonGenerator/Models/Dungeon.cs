using System.Collections;
using System.Collections.Generic;

namespace Game.Models
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
            Width = width;
            Height = height;
            _tiles = new char[width * height];
        }

        public Dungeon Fill(char c)
        {
            for (var i = 0; i < Width * Height; i++)
                _tiles[i] = c;
            return this;
        }

        public Dungeon Clear()
        {
            return Fill(' ');
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (var i = 0; i < Width * Height; i++)
                yield return _tiles[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
