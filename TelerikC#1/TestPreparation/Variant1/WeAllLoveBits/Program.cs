using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits
{
    class Program
    {
        static int InverseBits(int x)
        {
            int inversed = 0, shift = 0;
            while (x > 0)
            {
                inversed |= (1 - (x & 1)) << shift++;
                x >>= 1;
            }
            return inversed;
        }

        static int ReverseBits(int x)
        {
            int reversed = 0;
            while (x > 0)
            {
                reversed <<= 1;
                reversed |= x & 1;
                x >>= 1;
            }
            return reversed;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine((x ^ InverseBits(x)) & ReverseBits(x));
            }
        }
    }
}
