using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumWithAccuracy
{
    class SumWithAccuracy
    {
        static void Main(string[] args)
        {
            double currentSum = 1d;
            double nextSum = 1.5d;
            double currentNumber = 3;
            const double EPS = 1e-8;

            while (nextSum - currentSum >= EPS)
            {
                currentSum = nextSum;
                nextSum += 1d / currentNumber;
                currentNumber += 1d;
            }

            Console.WriteLine("{0:0.000}", currentSum);
        }
    }
}
