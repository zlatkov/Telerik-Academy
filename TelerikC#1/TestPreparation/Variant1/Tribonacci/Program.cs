using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger f1 = new BigInteger(int.Parse(Console.ReadLine()));
            BigInteger f2 = new BigInteger(int.Parse(Console.ReadLine()));
            BigInteger f3 = new BigInteger(int.Parse(Console.ReadLine()));

            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(f1);
            }
            else if (n == 2)
            {
                Console.WriteLine(f2);
            }
            else if (n == 3)
            {
                Console.WriteLine(f3);
            }
            else
            {
                BigInteger next;
                for (int i = 0; i < n - 3; ++i)
                {
                    next = f1 + f2 + f3;
                    f1 = f2;
                    f2 = f3;
                    f3 = next;
                }
                Console.WriteLine(f3);
            }
        }
    }
}
