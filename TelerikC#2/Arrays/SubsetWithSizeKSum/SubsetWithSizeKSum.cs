using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class SubsetWithSizeKSum
    {
        static bool[] use;

        static bool FindSubset(int[] sequence, int position, int length, int numberOfElements, int sum)
        {
            if (numberOfElements == 0)
            {
                if (sum == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (position >= length)
            {
                return false;
            }
            else
            {
                use[position] = true;
                bool found = FindSubset(sequence, position + 1, length, numberOfElements - 1, sum - sequence[position]);
                if (found)
                {
                    return true;
                }
                use[position] = false;
                found = FindSubset(sequence, position + 1, length, numberOfElements, sum);
                return found;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfElements = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            use = new bool[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            bool found = FindSubset(sequence, 0, n, numberOfElements, sum);
            if (found)
            {
                bool printed = false;
                for (int i = 0; i < n; ++i)
                {
                    if (use[i] == true)
                    {
                        if (printed)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(sequence[i]);
                        printed = true;
                    }
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("No such subsequence exists!");
            }
        }
    }
}
