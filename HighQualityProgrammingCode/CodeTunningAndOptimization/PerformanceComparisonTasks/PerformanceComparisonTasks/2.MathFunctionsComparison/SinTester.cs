using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MathFunctionsComparison
{
    public static class SinTester
    {
        public static void Sin(float number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin(number);
            }
        }

        public static void Sin(double number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin(number);
            }
        }

        public static void Sin(decimal number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin((double)number);
            }
        }
    }
}
