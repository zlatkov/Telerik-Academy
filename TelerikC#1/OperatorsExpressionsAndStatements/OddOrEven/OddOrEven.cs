using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OddOrEven
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            bool isEven = (number % 2) == 0;

            if (isEven)
            {
                Console.WriteLine("Number is even.");
            }
            else
            {
                Console.WriteLine("Number is odd.");
            }
        }
    }
}
