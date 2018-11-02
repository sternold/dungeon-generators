namespace Game.Generator.Strategy
{
    public class EmptyGeneratorStrategy : IStrategy
    {
        public Dungeon Generate(int w, int h)
        {
            return new Dungeon(w, h);
        }
    }
}
