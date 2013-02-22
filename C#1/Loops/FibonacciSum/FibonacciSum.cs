using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FibonacciSum
{
    class FibonacciSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            BigInteger previous = 0;
            BigInteger current = 1;
            BigInteger next;
            BigInteger sum = 1;

            for (int i = 3; i <= n; ++i)
            {
                next = current + previous;
                previous = current;
                current = next;

                sum += current;
            }

            Console.WriteLine(sum);
        }
    }
}
