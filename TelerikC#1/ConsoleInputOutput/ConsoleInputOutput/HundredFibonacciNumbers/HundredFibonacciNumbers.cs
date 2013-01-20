using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredFibonacciNumbers
{
    class HundredFibonacciNumbers
    {
        static void Main(string[] args)
        {
            decimal previous = 0;
            decimal current = 1;
            decimal next;

            Console.WriteLine("0\n1");

            for (int i = 3; i <= 100; ++i)
            {
                next = current + previous;
                previous = current;
                current = next;

                Console.WriteLine(current);
            }
        }
    }
}
