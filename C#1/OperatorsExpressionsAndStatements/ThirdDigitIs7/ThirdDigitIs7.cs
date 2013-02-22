using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirdDigitIs7
{
    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            bool thirdDigitsIsSeven = ((number / 100) % 10) == 7;

            Console.WriteLine(thirdDigitsIsSeven.ToString());
        }
    }
}
