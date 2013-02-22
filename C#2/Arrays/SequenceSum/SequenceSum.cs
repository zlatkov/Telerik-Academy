using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceSum
{
    class SequenceSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int sum = int.Parse(Console.ReadLine());
            int startIndex = -1;
            int endIndex = -1;
            bool found = false;

            for (int i = 0; i < n; ++i)
            {
                int currentSum = 0;
                for (int j = i; j < n; ++j)
                {
                    currentSum += sequence[j];
                    if (currentSum == sum)
                    {
                        startIndex = i;
                        endIndex = j;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            if (found)
            {
                for (int i = startIndex; i <= endIndex; ++i)
                {
                    if (i != startIndex)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(sequence[i]);
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("No such sequence exists.");
            }
        }
    }
}
