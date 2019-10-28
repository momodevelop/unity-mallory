using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const int WIDTH = 20;
        const int HEIGHT = 20;
        const int SECTION_HEIGHT = 4;
        const int MIN_BLOCK_WIDTH = 2;
        const int MIN_BLOCK_HEIGHT = 1;
        const int MAX_BLOCK_WIDTH = 4;
        const int MAX_BLOCK_HEIGHT = SECTION_HEIGHT;
        const int CHANCE_TO_PLACE_BLOCK = 0;

        ConsoleKeyInfo info;
        do
        {
            Console.Clear();
            int[,] level = LevelGenerator.GenerateLevel(
                WIDTH, HEIGHT,
                MIN_BLOCK_WIDTH, MIN_BLOCK_HEIGHT,
                MAX_BLOCK_WIDTH, MAX_BLOCK_HEIGHT,
                SECTION_HEIGHT, CHANCE_TO_PLACE_BLOCK);
            for (int i = level.GetLength(0) - 1; i >= 0; --i)
            {
                for (int j = 0; j < level.GetLength(1); ++j)
                {
                    Console.Write(level[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to generate, Q to quit");
            info = Console.ReadKey();

        } while (info.Key != ConsoleKey.Q);


    }
}

