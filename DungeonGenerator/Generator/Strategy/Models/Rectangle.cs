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
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        public bool Intersects(Rectangle other)
        {
            return X1 < other.X2
                && Y1 < other.Y2
                && other.X1 < X2
                && other.Y1 < Y2;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Rectangle;
            return X == other?.X
                && Y == other?.Y
                && W == other?.W
                && H == other?.H;
        }
    }
}
