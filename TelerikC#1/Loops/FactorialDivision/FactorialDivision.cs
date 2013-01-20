using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            BigInteger nFactorial = 1;
            BigInteger kFactorial = 1;

            for (int i = 1; i <= n; ++i)
            {
                nFactorial *= i;
            }

            for (int i = 1; i <= k; ++i)
            {
                kFactorial *= i;
            }

            Console.WriteLine(nFactorial / kFactorial);
        }
    }
}
