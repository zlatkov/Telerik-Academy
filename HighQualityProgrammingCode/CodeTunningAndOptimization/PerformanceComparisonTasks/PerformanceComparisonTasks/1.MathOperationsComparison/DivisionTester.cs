using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathOperationsComparison
{
    public static class DivisionTester
    {
        public static void Divide(int initialNumber, int divisor, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber /= divisor;
            }
        }

        public static void Divide(long initialNumber, long divisor, long repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber /= divisor;
            }
        }

        public static void Divide(float initialNumber, float divisor, float repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber /= divisor;
            }
        }

        public static void Divide(double initialNumber, double divisor, double repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber /= divisor;
            }
        }

        public static void Divide(decimal initialNumber, decimal divisor, decimal repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber /= divisor;
            }
        }
    }
}
