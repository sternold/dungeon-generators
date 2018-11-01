using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Generator.Strategy.Models
{
    public class Rectangle
    {
        public int X { get; }
        public int Y { get; }
        public int W { get; }
        public int H { get; }

        public int X1 => X;
        public int X2 => X + W;
        public int Y1 => Y;
        public int Y2 => Y + H;

        public Coord TopLeft => new Coord(X1, Y1);
        public Coord BottomRight => new Coord(X2, Y2);
        public Coord BottomLeft => new Coord(X1, Y2);
        public Coord TopRight => new Coord(X2, Y1);
        public Coord Center => new Coord((X1 + X2) / 2, (Y1 + Y2) / 2);

        public Rectangle(int x, int y, int w, int h)
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }

        public bool Intersects(Rectangle other)
        {
            return this.X1 < other.X2
                && this.Y1 < other.Y2
                && other.X1 < this.X2
                && other.Y1 < this.Y2;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Rectangle;
            return this.X == other?.X
                && this.Y == other?.Y
                && this.W == other?.W
                && this.H == other?.H;
        }
    }
}
