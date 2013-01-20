using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeDesiredBits
{
    class ExchangeDesiredBits
    {
        static void Main(string[] args)
        {
            uint number = Convert.ToUInt32(Console.ReadLine());
            int p = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < k; ++i)
            {
                int firstBitPosition = p + i;
                int secondBitPosition = q + i;

                int firstBitValue = Convert.ToInt32((number >> firstBitPosition) & 1);
                int secondBitValue = Convert.ToInt32((number >> secondBitPosition) & 1);

                number &= Convert.ToUInt32((~(1u << firstBitPosition)) & (~(1u << secondBitPosition)));
                number |= Convert.ToUInt32((secondBitValue<< firstBitPosition) | (firstBitValue << secondBitPosition));
            }

            Console.WriteLine(number);
        }
    }
}
