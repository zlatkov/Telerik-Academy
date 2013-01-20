using System;
using System.Linq;

namespace GenerateCombinations
{
    class GenerateCombinations
    {
        static int[] combination;
        static int combinationPosition;

        static void PrintCombinations(int lastElement, int left, int total, int n)
        {
            if (left == 0)
            {
                for (int i = 0; i < total; ++i)
                {
                    if (i != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(combination[i]);
                }
                Console.Write("\n");
            }
            if (left > 0)
            {

                for (int i = 1; i <= n; ++i)
                {
                    if (i > lastElement)
                    {
                        combination[combinationPosition++] = i;
                        PrintCombinations(i, left - 1, total, n);
                        combinationPosition--;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            combination = new int[k];

            PrintCombinations(0, k, k, n);
        }
    }
}
