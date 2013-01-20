using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberBiggerThanNeighbors
{
    class FindNumberBiggerThanNeighbors
    {
        static int DetermineIfBigger(int index, int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (index > 0 && index < sequenceLength - 1)
            {
                if (sequence[index] > sequence[index - 1] && sequence[index] > sequence[index + 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }

        static int FindFirstNumber(int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            int biggerThanNeighbors = 0;
            for (int i = 0; i < sequenceLength; ++i)
            {
                biggerThanNeighbors = DetermineIfBigger(i, sequence);
                if (biggerThanNeighbors == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] sequence = new int[sequenceLength];

            for (int i = 0; i < sequenceLength; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int foundIndex = FindFirstNumber(sequence);
            if (foundIndex >= 0)
            {
                Console.WriteLine("The first index of a number which is bigger than its neighbors is: {0}", foundIndex);
            }
            else
            {
                Console.WriteLine("No such index exists.");
            }
        }
    }
}
