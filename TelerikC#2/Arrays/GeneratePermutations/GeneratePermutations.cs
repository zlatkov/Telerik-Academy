using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePermutations
{
    class GeneratePermutations
    {
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void GeneratePerm(int[] elements, int position, int length)
        {
            if (position == length)
            {
                for (int i = 0; i < length; ++i)
                {
                    if (i > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(elements[i]);
                }
                Console.Write("\n");
            }
            else
            {
                GeneratePerm(elements, position + 1, length);
                for (int i = position + 1; i < length; ++i)
                {
                    Swap(ref elements[position], ref elements[i]);
                    GeneratePerm(elements, position + 1, length);
                    Swap(ref elements[position], ref elements[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] elements = new int[n];
            for (int i = 0; i < n; ++i)
            {
                elements[i] = i + 1;
            }

            GeneratePerm(elements, 0, n);
        }
    }
}
