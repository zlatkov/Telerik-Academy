using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] t = new long[228];
            for (int i = 0; i < 3; ++i)
            {
                t[i] = long.Parse(Console.ReadLine());
            }


            int lines = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}\n{1} {2}", t[0], t[1], t[2]);
            int lastIndex = 3;

            for (int i = 3; i <= lines; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    t[lastIndex] = t[lastIndex - 3] + t[lastIndex - 2] + t[lastIndex - 1];
                    if (j != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(t[lastIndex++]);
                }
                Console.Write("\n");
            }
        }
    }
}
