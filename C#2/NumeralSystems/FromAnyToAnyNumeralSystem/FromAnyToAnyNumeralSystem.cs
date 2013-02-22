using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromAnyToAnyNumeralSystem
{
    class FromAnyToAnyNumeralSystem
    {
        static int GetInt(char ch)
        {
            if (ch >= 'A' && ch <= 'F')
            {
                return ch - 'A' + 10;
            }
            else
            {
                return ch - '0';
            }
        }

        static string ConvertToDecimal(string number, int numberBase)
        {
            int result = 0;
            int pow = 1;
            for (int i = number.Length - 1; i >= 0;  --i)
            {
                result += GetInt(number[i]) * pow;
                pow *= numberBase;
            }

            return result.ToString();
        }

        static string ConvertFromDecimal(string number, int toBase)
        {
            int numberInt = int.Parse(number);
            string result = "";

            while (numberInt > 0)
            {
                result = (numberInt % toBase) + result;
                numberInt /= toBase;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the base in which the number is represented: ");
            int fromNumeralSystem = int.Parse(Console.ReadLine());

            Console.Write("Enter the base in which you want to convert the numer: ");
            int toNumeralSystem = int.Parse(Console.ReadLine());

            Console.Write("Enter the number: ");
            string number = Console.ReadLine();

            string decimalNumber = ConvertToDecimal(number, fromNumeralSystem);
            string result = ConvertFromDecimal(decimalNumber, toNumeralSystem);

            Console.WriteLine(result);
        }
    }
}
