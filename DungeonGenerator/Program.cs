using Game.Generator;
using Game.Generator.Strategy;
using System;

namespace Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WindowWidth = 144;
            Console.WindowHeight = 48;

            var generator = new DungeonGenerator(new SimpleGeneratorStrategy(12));
            var dungeon = generator.Generate(Console.WindowWidth, Console.WindowHeight);

            Draw(dungeon);
            Console.Read();
        }

        private static void Draw(Dungeon dungeon)
        {
            for(var y = 0; y < dungeon.Height; y++)
            {
                for (var x = 0; x < dungeon.Width; x++)
                {
                    Console.CursorTop = y;
                    Console.CursorLeft = x;
                    Console.Write(dungeon[x, y]);
                }
            }
        }
    }
}
