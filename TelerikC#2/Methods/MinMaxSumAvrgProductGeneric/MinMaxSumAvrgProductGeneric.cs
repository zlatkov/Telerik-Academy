using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSumAvrgProductGeneric
{
    class MinMaxSumAvrgProductGeneric
    {
        static T Min<T>(params T[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                if (sequenceLength == 2)
                {
                    dynamic x = sequence[0];
                    dynamic y = sequence[1];
                    return x < y ? x : y;
                }
                else
                {
                    dynamic result = sequence[0];
                    for (int i = 1; i < sequenceLength; ++i)
                    {
                        result = Min(result, sequence[i]);
                    }
                    return result;
                }
            }
            else
            {
                return default(T);
            }
        }

        static T Max<T>(params T[] sequence) 
        {
            int sequenceLength = sequence.GetLength(0);
            if (sequenceLength > 0)
            {
                if (sequenceLength == 2)
                {
                    dynamic x = sequence[0];
                    dynamic y = sequence[1];
                    return x > y ? x : y;
                }
                else
                {
                    dynamic result = sequence[0];
                    for (int i = 0; i < sequenceLength; ++i)
                    {
                        result = Max<T>(result, sequence[i]);
                    }

                    return result;
                }
            }
            return default(T);
        }

        static T Sum<T>(params T[] sequence)
        {
            if (sequence.GetLength(0) > 0)
            {
                dynamic sum = 0;
                foreach (T x in sequence)
                {
                    sum += x;
                }
                return sum;
            }
            else
            {
                return default(T);
            }
        }

        static T Average<T>(params T[] sequence)
        {
            int sequenceLength = sequence.GetLength(0);

            if (sequenceLength > 0)
            {
                dynamic sum = 0;
                foreach (T x in sequence)
                {
                    sum += x;
                }

                return sum / sequenceLength;
            }
            else
            {
                return default(T);
            }
        }

        static T Product<T>(params T[] sequence)
        {
            if (sequence.GetLength(0) > 0)
            {
                dynamic product = 1;
                foreach (T x in sequence)
                {
                    product *= x;
                }

                return product;
            }
            else
            {
                return default(T);
            }
        }

        static void Main(string[] args)
        {
            decimal min = Min<decimal>(6.1m, 3.11111m, 2.543m);
            decimal max = Max<decimal>(6.1m, 3.11111m, 2.543m);
            decimal sum = Sum<decimal>(6.1m, 3.11111m, 2.543m);
            decimal average = Average<decimal>(6.1m, 3.11111m, 2.543m);
            decimal product = Product<decimal>(6.1m, 3.11111m, 2.543m);

            Console.WriteLine("Min: {0}.\nMax: {1}.\nSum: {2}.\nAverage: {3}.\nProduct: {4}.", min, max, sum, average, product);
        }
    }
}
