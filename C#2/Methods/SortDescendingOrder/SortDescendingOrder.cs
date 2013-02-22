using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDescendingOrder
{
    class SortDescendingOrder
    {
        static int MaximalValueInex(int index, int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                int maxValueIndex = index;
                for (int i = index + 1; i < sequenceLength; ++i)
                {
                    if (sequence[i] > sequence[maxValueIndex])
                    {
                        maxValueIndex = i;
                    }
                }
                return maxValueIndex;
            }
            else
            {
                return -1;
            }
        }

        static void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        static void SortArrayDescending(int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                int maxValueIndex = 0;
                for (int i = 0; i < sequenceLength - 1; ++i)
                {
                    maxValueIndex = MaximalValueInex(i, sequence);
                    if (i != maxValueIndex)
                    {
                        Swap(ref sequence[i], ref sequence[maxValueIndex]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            SortArrayDescending(sequence);

            for (int i = 0; i < n; ++i)
            {
                if (i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(sequence[i]);
            }
            Console.Write("\n");

        }
    }
}
