using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            const int maxRange = 10000000;
            bool[] isPrime = new bool[maxRange + 1];

            for (int i = 0; i <= maxRange; ++i)
            {
                isPrime[i] = true;
            }

            isPrime[1] = false;
            for (int i = 2; i <= maxRange; ++i)
            {
                if (isPrime[i])
                {
                    Console.WriteLine(i);
                    if (i <= 3163)
                    {
                        for (int j = i * i; j <= maxRange; j += i)
                        {
                            isPrime[j] = false;
                        }
                    }
                }
            }
        }
    }
}
