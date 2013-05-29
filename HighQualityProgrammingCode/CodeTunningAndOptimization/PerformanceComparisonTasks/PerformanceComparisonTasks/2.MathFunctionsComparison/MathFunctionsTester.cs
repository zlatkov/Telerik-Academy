using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MathFunctionsComparison
{
    class MathFunctionsTester
    {
        static void Main(string[] args)
        {
            // Testing log.
            LogTester.Log(1000f, 10000000);
            LogTester.Log(1000d, 10000000);
            LogTester.Log(1000m, 10000000);
                                     
            // Testing sin.          
            SinTester.Sin(1000f, 10000000);
            SinTester.Sin(1000d, 10000000);
            SinTester.Sin(1000m, 10000000);
                                     
            // Testing sqrt.         
            SqrtTester.Sqrt(1000f, 10000000);
            SqrtTester.Sqrt(1000d, 10000000);
            SqrtTester.Sqrt(1000m, 10000000);
        }
    }
}
