using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumbersNotDivisibleByThreeAndSeven
{
    class FindNumbersNotDivisibleByThreeAndSeven
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; ++i)
            {
                if (!(i % 3 == 0 || i % 7 == 0))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
