using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionSum
{
    class FractionSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter X: ");
            int x = Convert.ToInt32(Console.ReadLine());

            double sum = 1d;
            ulong nFactorial = 1;
            ulong xPow = 1ul;

            for (int i = 1; i <= n; ++i)
            {
                nFactorial *= (ulong)i;
                xPow *= (ulong)x;

                sum += (double)nFactorial / (double)xPow;
            }

            Console.WriteLine(sum);

        }
    }
}
