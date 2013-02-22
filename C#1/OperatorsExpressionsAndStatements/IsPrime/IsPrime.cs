using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsPrime
{
    class IsPrime
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            bool isPrime = true;
            for (int i = 2; i * i <= number; ++i)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("The number is prime.");
            }
            else
            {
                Console.WriteLine("The number is not prime.");
            }
        }
    }
}
