using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceOfMaximalSum
{
    class SequenceOfMaximalSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            if (n > 0)
            {
                int currentMaximalEnding = sequence[0];
                int totalMaximalEnding = sequence[0];
                int begin = 0, currentBegin = 0;
                int end = 0;

                for (int i = 1; i < n; ++i)
                {
                    currentMaximalEnding += sequence[i];
                    if (sequence[i] > currentMaximalEnding)
                    {
                        currentMaximalEnding = sequence[i];
                        currentBegin = i;
                    }
                    if (currentMaximalEnding > totalMaximalEnding)
                    {
                        totalMaximalEnding = currentMaximalEnding;
                        begin = currentBegin;
                        end = i;
                    }
                }

                for (int i = begin; i <= end; ++i)
                {
                    if (i != begin)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(sequence[i]);
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("The sequence is empty.");
            }
        }
    }
}
