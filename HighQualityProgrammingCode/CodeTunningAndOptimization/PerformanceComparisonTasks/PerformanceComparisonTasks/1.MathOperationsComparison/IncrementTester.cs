using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathOperationsComparison
{
    public static class IncrementTester
    {
        public static void Increment(int initialNumber, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber++;
            }
        }

        public static void Increment(long initialNumber, long repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber++;
            }
        }

        public static void Increment(float initialNumber, float repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber++;
            }
        }

        public static void Increment(double initialNumber, double repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber++;
            }
        }

        public static void Increment(decimal initialNumber, decimal repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber++;
            }
        }
    }
}
