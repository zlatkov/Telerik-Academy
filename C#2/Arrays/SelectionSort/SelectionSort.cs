using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int currentMinimalIndex = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                currentMinimalIndex = i;
                for (int j = i + 1; j < n; ++j)
                {
                    if (sequence[j] < sequence[currentMinimalIndex])
                    {
                        currentMinimalIndex = j;
                    }
                }

                Swap(ref sequence[i], ref sequence[currentMinimalIndex]);
            }

            for (int i = 0; i < n; ++i)
            {
                if (i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(sequence[i]);
            }
            Console.Write("\n");
        }
    }
}
