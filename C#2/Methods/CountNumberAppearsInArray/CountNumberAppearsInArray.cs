using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumberAppearsInArray
{
    class CountNumberAppearsInArray
    {
        static int GetNumberOfOccurrences(int number, int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            int numberOfOccurances = 0;
            for (int i = 0; i < sequenceLength; ++i)
            {
                if (sequence[i] == number)
                {
                    numberOfOccurances++;
                }
            }

            return numberOfOccurances;
        }
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] sequence = new int[sequenceLength];

            for (int i = 0; i < sequenceLength; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int number = int.Parse(Console.ReadLine());
            int numberOfOccurances = GetNumberOfOccurrences(number, sequence);

            Console.WriteLine("The number {0} appears {1} times in the array.", number, numberOfOccurances);
        }
    }
}
