using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivisableBy5And7
{
    class DivisableBy5And7
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            bool isDivisable = (number % 5 == 0) && (number % 7 == 0);
            if (isDivisable)
            {
                Console.WriteLine("The number is divisable by 5 and 7.");
            }
            else
            {
                Console.WriteLine("The number isn't divisable by 5 and 7.");
            }
        }
    }
}
