using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToHex
{
    class DecimalToHex
    {
        static char GetSymbol(int x)
        {
            if (x >= 0 && x < 10)
            {
                return (char)(x + '0');
            }
            else
            {
                return (char)('A' + x - 10);
            }
        }

        static string ConvertDecimalToHex(int decimalNumber)
        {
            string result = "";
            while (decimalNumber > 0)
            {
                result = GetSymbol(decimalNumber % 16) + result;
                decimalNumber /= 16;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            string hexNumber = ConvertDecimalToHex(decimalNumber);

            Console.WriteLine(hexNumber);
        }
    }
}
