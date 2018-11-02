namespace Game.Generator.Strategy.Models
{
    public class Coord
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
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
