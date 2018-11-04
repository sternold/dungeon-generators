using Game.Generator;
using Game.Generator.Strategy;
using System;
using System.Linq;
using Game.Models;

namespace Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WindowWidth = 144;
            Console.WindowHeight = 48;

            var generator = new DungeonGenerator();
            while (true)
            {
                generator.Strategy = new EmptyGeneratorStrategy();
                Draw(generator.Generate(Console.WindowWidth, Console.WindowHeight));
                Console.ReadLine();
                generator.Strategy = new NaturalDungeonStrategy();
                Draw(generator.Generate(Console.WindowWidth, Console.WindowHeight));
                Console.ReadLine();
                generator.Strategy = new SimpleGeneratorStrategy();
                Draw(generator.Generate(Console.WindowWidth, Console.WindowHeight));
                Console.ReadLine(); 
            }
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
            Console.WriteLine("floors: " + dungeon.Count(c => c == '.'));
        }
    }
}
