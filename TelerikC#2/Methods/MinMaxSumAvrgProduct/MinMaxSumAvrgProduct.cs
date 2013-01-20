using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSumAvrgProduct
{
    class MinMaxSumAvrgProduct
    {
        static int Min(params int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                if (sequenceLength == 2)
                {
                    return sequence[0] < sequence[1] ? sequence[0] : sequence[1];
                }
                else
                {
                    int result = sequence[0];
                    for (int i = 1; i < sequenceLength; ++i)
                    {
                        result = Math.Min(result, sequence[i]);
                    }
                    return result;
                }
            }
            else
            {
                return 0;
            }
        }

        static int Max(params int[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                if (sequenceLength == 2)
                {
                    return sequence[0] > sequence[1] ? sequence[0] : sequence[1];
                }
                else
                {
                    int result = sequence[0];
                    for (int i = 1; i < sequenceLength; ++i)
                    {
                        result = Max(result, sequence[i]);
                    }
                    return result;
                }
            }
            else
            {
                return 0;
            }
        }

        static int Sum(params int[] sequence)
        {
            int sum = 0;
            foreach (int x in sequence)
            {
                sum += x;
            }
            return sum;
        }

        static int Average(params int[] sequence)
        {
            int sum = 0, sequenceLength = sequence.GetLength(0);
            foreach (int x in sequence)
            {
                sum += x;
            }

            return sum / sequenceLength;
        }

        static int Product(params int[] sequence)
        {
            if (sequence.GetLength(0) > 0)
            {
                int product = 1;
                foreach (int x in sequence)
                {
                    product *= x;
                }

                return product;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            int min = Min(6, 3, 2);
            int max = Max(6, 3, 2);
            int sum = Sum(6, 3, 2);
            int average = Average(6, 3, 2);
            int product = Product(6, 3, 2);

            Console.WriteLine("Min: {0}.\nMax: {1}.\nSum: {2}.\nAverage: {3}.\nProduct: {4}.", min, max, sum, average, product);
        }
    }
}
