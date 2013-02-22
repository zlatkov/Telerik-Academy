using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastMajorityMultiple
{
    class Program
    {
        static ulong Gcd(ulong x, ulong y)
        {
            if (y == 0)
            {
                return x;
            }
            return Gcd(y, x % y);
        }

        static ulong Lcm(ulong x, ulong y)
        {
            return (x * y) / Gcd(x, y);
        }

        static void Main(string[] args)
        {
            ulong[] x = new ulong[5];
            ulong minMultiple = 1ul;

            for (int i = 0; i < 5; ++i)
            {
                x[i] = ulong.Parse(Console.ReadLine());
                minMultiple *= x[i];
            }



            for (int i = 0; i < 5; ++i)
            {
                for (int j = i + 1; j < 5; ++j)
                {
                    for (int k = j + 1; k < 5; ++k)
                    {
                        minMultiple = Math.Min(minMultiple, Lcm(x[i], Lcm(x[j], x[k])));
                    }
                }
            }

            Console.WriteLine(minMultiple);
        }
    }
}
