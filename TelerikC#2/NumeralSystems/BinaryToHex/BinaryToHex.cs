using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToHex
{
    class BinaryToHex
    {
        static char GetChar(int x)
        {
            if (x >= 10)
            {
                return (char)('A' + x - 10);
            }
            else
            {
                return (char)(x + '0');
            }
        }

        static int GetInt(char x)
        {
            return (int)(x - '0');
        }

        static string ConvertBinaryToHex(string binaryNumber)
        {
            string result = "";
            int tmp = 0, exp = 1;
            for (int i = binaryNumber.Length - 1; i >= 0;)
            {
                tmp = 0;
                exp = 1;
                for (int j = 0; j < 4 && i >= 0; ++j, --i)
                {
                    tmp += GetInt(binaryNumber[i]) * exp;
                    exp <<= 1;
                }

                result = GetChar(tmp) + result;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string binaryNumber = Console.ReadLine();
            string hexNumber = ConvertBinaryToHex(binaryNumber);

            Console.WriteLine(hexNumber);
        }
    }
}
