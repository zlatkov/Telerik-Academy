using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathOperationsComparison
{
    public static class SubtractionTester
    {
        public static void Subtract(int initialNumber, int numberToSubtract, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber -= numberToSubtract;
            }
        }

        public static void Subtract(long initialNumber, long numberToSubtract, long repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber -= numberToSubtract;
            }
        }

        public static void Subtract(float initialNumber, float numberToSubtract, float repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber -= numberToSubtract;
            }
        }

        public static void Subtract(double initialNumber, double numberToSubtract, double repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber -= numberToSubtract;
            }
        }

        public static void Subtract(decimal initialNumber, decimal numberToSubtract, decimal repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber -= numberToSubtract;
            }
        }
    }
}
