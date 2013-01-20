using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int result = 0;
            int lastBit = 1;
            int currentLength = 0;

            for (int p = 0; p < n; ++p)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                int firstBitOneIndex = 31;
                for (int i = 31; i >= 0; --i)
                {
                    if (((currentNumber >> i) & 1) > 0)
                    {
                        firstBitOneIndex = i;
                        break;
                    }
                }

                for (int i = firstBitOneIndex; i >= 0; --i)
                {
                    int currentBit = (currentNumber >> i) & 1;
                    if (currentBit == lastBit)
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength == k)
                        {
                            result++;
                        }
                        currentLength = 1;
                    }
                    lastBit = currentBit;
                }
            }

            if (currentLength == k)
            {
                result++;
            }

            Console.WriteLine(result);
        }
    }
}
