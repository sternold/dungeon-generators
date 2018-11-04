using Game.Models;

namespace Game.Generator.Strategy
{
    public interface IStrategy
    {
        Dungeon Generate(int w, int h);
    }
}
