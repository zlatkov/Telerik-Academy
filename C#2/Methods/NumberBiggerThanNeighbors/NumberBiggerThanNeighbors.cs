using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBiggerThanNeighbors
{
    class NumberBiggerThanNeighbors
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

        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] sequence = new int[sequenceLength];

            for (int i = 0; i < sequenceLength; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int index = int.Parse(Console.ReadLine());
            int result = DetermineIfBigger(index, sequence);

            if (result == 1)
            {
                Console.WriteLine("The number at index {0} is bigger than its two neighbors.", index);
            }
            else if (result == 0)
            {
                Console.WriteLine("The number at index {0} is not bigger than its two neighbors.", index);
            }
            else
            {
                Console.WriteLine("The number at index {0} doesn't have 2 neighbors.", index);
            }
        }
    }
}
