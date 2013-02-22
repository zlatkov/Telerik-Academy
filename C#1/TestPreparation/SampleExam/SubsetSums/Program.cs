using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = long.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int result = 0;
            long[] seq = new long[n];

            for (int i = 0; i < n; ++i)
            {
                seq[i] = long.Parse(Console.ReadLine());
            }

            for (int mask = 1; mask < (1 << n); ++mask)
            {
                long tmpSum = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (((mask >> i) & 1) > 0)
                    {
                        tmpSum += seq[i];
                    }
                }
                if (tmpSum == sum)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
