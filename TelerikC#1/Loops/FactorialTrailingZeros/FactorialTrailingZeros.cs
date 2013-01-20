using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialTrailingZeros
{
    class FactorialTrailingZeros
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int numberTrailingZeros = 0;
            for (int i = 5; i <= n; ++i)
            {
                int tmp = i;
                while (tmp % 5 == 0)
                {
                    numberTrailingZeros++;
                    tmp /= 5;
                }
            }

            Console.WriteLine(numberTrailingZeros);
        }
    }
}
