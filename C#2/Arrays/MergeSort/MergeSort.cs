using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class MergeSort
    {

        static int[] MergeSortSequence(int[] sequence, int n)
        {
            if (n <= 1)
            {
                return sequence;
            }

            int leftPartSize = n >> 1;
            int rightPartSize = (n + 1) >> 1;

            int[] leftPart = new int[leftPartSize];
            int[] rightPart = new int[rightPartSize];
            int[] sortedSequence = new int[n];

            for (int i = 0; i < leftPartSize; ++i)
            {
                leftPart[i] = sequence[i];
            }
            for (int i = 0; i < rightPartSize; ++i)
            {
                rightPart[i] = sequence[leftPartSize + i];
            }

            leftPart = MergeSortSequence((int[])leftPart.Clone(), leftPartSize);
            rightPart = MergeSortSequence((int[])rightPart.Clone(), rightPartSize);

            int leftIndex = 0;
            int rightIndex = 0;
            int sortedIndex = 0;

            while (leftIndex < leftPartSize || rightIndex < rightPartSize)
            {
                if (leftIndex == leftPartSize)
                {
                    sortedSequence[sortedIndex++] = rightPart[rightIndex++];
                }
                else if (rightIndex == rightPartSize)
                {
                    sortedSequence[sortedIndex++] = leftPart[leftIndex++];
                }
                else
                {
                    if (leftPart[leftIndex] < rightPart[rightIndex])
                    {
                        sortedSequence[sortedIndex++] = leftPart[leftIndex++];
                    }
                    else
                    {
                        sortedSequence[sortedIndex++] = rightPart[rightIndex++];
                    }
                }
            }

            return sortedSequence;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());   
            }

            sequence = MergeSortSequence((int[])sequence.Clone(), n);

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
