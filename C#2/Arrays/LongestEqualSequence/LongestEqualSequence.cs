using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestEqualSequence
{
    class LongestEqualSequence
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

                int maximalLength = 1;
                int tmpMaximalLength = 1;
                int begin = 0, end = 0;
                int tmpBegin = 0;

                for (int i = 1; i < n; ++i)
                {
                    if (sequence[i] == sequence[i - 1])
                    {
                        tmpMaximalLength++;
                    }
                    else
                    {
                        tmpBegin = i;
                        tmpMaximalLength = 1;
                    }
                    if (tmpMaximalLength > maximalLength)
                    {
                        maximalLength = tmpMaximalLength;
                        begin = tmpBegin;
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
                Console.WriteLine("The sequene is empty.");
            }
        }
    }
}
