using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
    class NumberToText
    {
        static void Main(string[] args)
        {
            string[] tens = new string[] 
            {
                "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            string[] toNineteen = new string[]
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            int number;
            do
            {
                Console.Write("Enter a number: ");
                number = Convert.ToInt32(Console.ReadLine());
            } while (number < 0 || number > 1000);

            int firstDigit = number / 100;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = number % 10;

            string result = "";

            if (number >= 100)
            {
                result = toNineteen[firstDigit] + " hundred";
                if (secondDigit <= 1 && (secondDigit * 10 + thirdDigit > 0))
                {
                    result += " and " + toNineteen[secondDigit * 10 + thirdDigit];
                }
                else if (secondDigit > 1 && thirdDigit == 0)
                {
                    result += " and " + tens[secondDigit - 2];
                }
                else if (secondDigit > 1 && thirdDigit > 0)
                {
                    result += " " + tens[secondDigit - 2] + " " + toNineteen[thirdDigit];
                }
            }
            else 
            {
                if (secondDigit <= 1)
                {
                    result = toNineteen[secondDigit * 10 + thirdDigit];
                }
                else
                {
                    result = tens[secondDigit - 2];
                    if (thirdDigit != 0)
                    {
                        result += " " + toNineteen[thirdDigit];
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
