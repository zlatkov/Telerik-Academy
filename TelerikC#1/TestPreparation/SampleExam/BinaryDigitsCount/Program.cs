using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            uint digit = uint.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int k = 0; k < n; ++k)
            {
                uint number = uint.Parse(Console.ReadLine());

                int numberOfMatchingDigits = 0;
                while (number > 0)
                {
                    if ((number & 1) == digit)
                    {
                        numberOfMatchingDigits++;
                    }
                    number >>= 1;
                }
                Console.WriteLine(numberOfMatchingDigits);
            }
        }
    }  
}
