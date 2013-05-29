using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathOperationsComparison
{
    public static class MultiplicationTester
    {
        public static void Multiply(int initialNumber, int multiplier, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber *= multiplier;
            }
        }

        public static void Multiply(long initialNumber, long multiplier, long repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber *= multiplier;
            }
        }

        public static void Multiply(float initialNumber, float multiplier, float repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber *= multiplier;
            }
        }

        public static void Multiply(double initialNumber, double multiplier, double repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber *= multiplier;
            }
        }

        public static void Multiply(decimal initialNumber, decimal multiplier, decimal repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber *= multiplier;
            }
        }
    }
}
