using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexToDecimal
{
    class HexToDecimal
    {
        static int GetInt(char ch)
        {
            if (ch >= 'A')
            {
                return (int)(ch - 'A' + 10);
            }
            else
            {
                return (int)(ch - '0');
            }
        }
        static int ConvertHexToDecimal(string hexNumber)
        {
            int result = 0, exp = 1;
            for (int i = hexNumber.Length - 1; i >= 0; --i)
            {
                result += GetInt(hexNumber[i]) * exp;
                exp *= 16;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string hexNumber = Console.ReadLine();
            int decimalNumber = ConvertHexToDecimal(hexNumber);

            Console.WriteLine(decimalNumber);
        }
    }
}
