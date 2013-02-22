using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());

            int numberOfAsterix = 1;
            int width = 2 * height - 3;

            int numberSkip = width >> 1;

            for (int i = 1; i < height; ++i)
            {
                int tmp = numberOfAsterix;
                for (int j = 1; j <= width; ++j)
                {
                    if (j > numberSkip && tmp > 0)
                    {
                        Console.Write("*");
                        tmp--;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.Write("\n");
                numberOfAsterix += 2;
                numberSkip--;
            }
            for (int i = 1; i <= width; ++i)
            {
                if (i == (width >> 1) + 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.Write("\n");
        }
    }
}
