using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MathFunctionsComparison
{
    public static class LogTester
    {
        public static void Log(float number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Log(number, Math.E);
            }
        }

        public static void Log(double number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Log(number, Math.E);
            }
        }

        public static void Log(decimal number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Log((double)number, Math.E);
            }
        }
    }
}
