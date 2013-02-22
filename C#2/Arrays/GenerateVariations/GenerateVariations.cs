using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateVariations
{
    class GenerateVariations
    {
        static int[] variation;
        static int variationPosition;

        static void PrintVariations(int left, int total, int n)
        {
            if (left == 0)
            {
                for (int i = 0; i < total; ++i)
                {
                    if (i != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(variation[i]);
                }
                Console.Write("\n");
            }
            if (left > 0)
            {

                for (int i = 1; i <= n; ++i)
                {
                    variation[variationPosition++] = i;
                    PrintVariations(left - 1, total, n);
                    variationPosition--;
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
             
            variation = new int[k];

            PrintVariations(k, k, n);
        }
    }
}
