using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= (n << 1); ++i)
            {
                if (i > n)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.Write("\n");

            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = 1; j <= (n << 1) - 1; ++j)
                {
                    if (n - i == j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("*\n");
            }
            for (int i = 0; i < (n << 1); ++i)
            {
                Console.Write("*");
            }
            Console.Write("\n");

        }
    }
}
