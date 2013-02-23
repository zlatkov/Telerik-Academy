using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.FilterDivisibleBy3And7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                1, 432, 2, 3, 27, 29, 21, 30, 49, 59, 60, 100, 21343, 63
            };

            var filteredWithLambda = numbers.Where(number => number % 3 == 0 && number % 7 == 0);
            foreach (int number in filteredWithLambda)
            {
                Console.WriteLine(number);
            }
            Console.Write("\n");

            var filteredWithLinq =
                from number in numbers
                where number % 3 == 0 && number % 7 == 0
                select number;

            foreach (int number in filteredWithLinq)
            {
                Console.WriteLine(number);
            }
        }
    }
}
