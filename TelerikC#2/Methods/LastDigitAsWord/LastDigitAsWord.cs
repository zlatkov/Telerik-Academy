using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastDigitAsWord
{
    class LastDigitAsWord
    {
        static string GetLastDigitAsWord(int number)
        {
            if (number < 0)
            {
                number = -number;
            }
            int lastDigit = number % 10;
            string result = "";

            switch (lastDigit)
            {
                case 0: result = "zero"; break;
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
            }

            return result;
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string lastdigitAsWord = GetLastDigitAsWord(number);
            Console.WriteLine(lastdigitAsWord);
        }
    }
}
