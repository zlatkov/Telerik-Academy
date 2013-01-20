using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseDigits
{
    class ReverseDigits
    {
        static int ReverseDigitsOfNumber(int number)
        {
            bool numberIsNegative = false;
            if (number < 0)
            {
                numberIsNegative = true;
                number = -number;
            }

            int numberWithReversedDigits = 0;
            while (number > 0)
            {
                numberWithReversedDigits = (numberWithReversedDigits * 10) + (number % 10);
                number /= 10;
            }

            if (numberIsNegative)
            {
                numberWithReversedDigits = -numberWithReversedDigits;
            }

            return numberWithReversedDigits;
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int numberWithReversedDigits = ReverseDigitsOfNumber(number);
            Console.WriteLine(numberWithReversedDigits);
        }
    }
}
