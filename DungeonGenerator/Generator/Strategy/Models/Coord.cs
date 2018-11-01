using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy.Models
{
    public class Coord
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coord Offset(Coord other)
        {
            return new Coord(X - other.X, Y - other.Y);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Coord;
            return X == other?.X && Y == other?.Y;
        }
    }
}
