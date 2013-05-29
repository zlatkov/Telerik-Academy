using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathOperationsComparison
{
    public static class AdditionTester
    {
        public static void Add(int initialNumber, int numberToAdd, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber += numberToAdd;
            }
        }

        public static void Add(long initialNumber, long numberToAdd, long repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber += numberToAdd;
            }
        }

        public static void Add(float initialNumber, float numberToAdd, float repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber += numberToAdd;
            }
        }

        public static void Add(double initialNumber, double numberToAdd, double repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber += numberToAdd;
            }
        }

        public static void Add(decimal initialNumber, decimal numberToAdd, decimal repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                initialNumber += numberToAdd;
            }
        }
    }
}
