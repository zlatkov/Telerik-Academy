using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CatalanNumber
{
    class CatalanNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            BigInteger numerator = 1;
            BigInteger denominator = 1;

            for (int i = 1; i <= n; ++i)
            {
                numerator *= 2 * i * (2 * i - 1);
                denominator = denominator * i * (i + 1);
            }
            Console.WriteLine(numerator / denominator);
        }
    }
}
