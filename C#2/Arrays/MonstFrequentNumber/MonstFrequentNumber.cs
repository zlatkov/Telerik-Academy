using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonstFrequentNumber
{
    class MonstFrequentNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int currentFrequency = 0;
            int maximalFrequency = 0;
            int resultIndex = -1;

            for (int i = 0; i < n; ++i)
            {
                currentFrequency = 0;
                for (int j = 0; j < n; ++j)
                {
                    if (sequence[i] == sequence[j])
                    {
                        currentFrequency++;
                    }
                }
                if (currentFrequency > maximalFrequency)
                {
                    maximalFrequency = currentFrequency;
                    resultIndex = i;
                }
            }

            if (n > 0)
            {
                Console.WriteLine(sequence[resultIndex]);
            }
            else
            {
                Console.WriteLine("The sequence is empty.");
            }
        }
    }
}
