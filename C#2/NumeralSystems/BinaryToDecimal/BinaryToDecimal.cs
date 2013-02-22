using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static int ConvertBinaryToDecimal(string binaryNumber)
        {
            int result = 0;
            int exp = 1;

            for (int i = binaryNumber.Length - 1; i >= 0; --i)
            {
                result += (int)(binaryNumber[i] - '0') * exp;
                exp *= 2;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string binaryNumber = Console.ReadLine();
            int decimalNumber = ConvertBinaryToDecimal(binaryNumber);

            Console.WriteLine(decimalNumber);
        }
    }
}
