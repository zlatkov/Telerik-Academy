using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactorialMultiplicationAndDivision
{
    class FactorialMultiplicationAndDivision
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            BigInteger nFactorial = 1;
            BigInteger kMinusNplusOneFactorial = 1;

            for (int i = 2; i <= n; ++i)
            {
                nFactorial *= i;
            }

            for (int i = k; i >= k - n + 1; --i)
            {
                kMinusNplusOneFactorial *= i;
            }

            Console.WriteLine(nFactorial * kMinusNplusOneFactorial);
        }
    }
}
