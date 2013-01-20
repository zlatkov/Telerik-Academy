using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    class GreatestCommonDivisor
    {
        static int Gcd(int x, int y)
        {
            if (y == 0)
            {
                return x;
            }
            return Gcd(y, x % y);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Gcd(x, y));
        }
    }
}
