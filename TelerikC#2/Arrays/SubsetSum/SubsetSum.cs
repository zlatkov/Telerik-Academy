using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class SubsetSum
    {
        static bool[] use;

        static bool FindSubset(int[] sequence, int position, int length, int sum)
        {
            if (position >= length)
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
            else
            {
                use[position] = true;
                bool found = FindSubset(sequence, position + 1, length, sum - sequence[position]);
                if (found)
                {
                    return true;
                }

                use[position] = false;
                found = FindSubset(sequence, position + 1, length, sum);
                return found;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            use = new bool[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            bool found = FindSubset(sequence, 0, n, sum);
            if (found)
            {
                Console.WriteLine("Yes.");
                bool isPrinted = false;
                for (int i = 0; i < n; ++i)
                {
                    if (use[i])
                    {
                        if (isPrinted)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(sequence[i]);
                        isPrinted = true;
                    }
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
    }
}
