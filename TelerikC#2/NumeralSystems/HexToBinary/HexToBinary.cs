using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexToBinary
{
    class HexToBinary
    {
        static byte GetByte(char ch)
        {
            if (ch >= 'A')
            {
                return (byte)(ch - 'A' + 10);
            }
            else
            {
                return (byte)(ch - '0');
            }
        }

        static string ConvertHexToBinary(string hexNumber)
        {
            string result = "";
            byte tmp = 0;
            for (int i = hexNumber.Length - 1; i >= 0; --i )
            {
                tmp = GetByte(hexNumber[i]);
                for (int j = 0; j < 4; ++j)
                {
                    result = (tmp & 1) + result;
                    tmp >>= 1;
                }
            }

            result = result.TrimStart('0');

            return result;
        }

        static void Main(string[] args)
        {
            string hexNumber = Console.ReadLine();
            string binaryNumber = ConvertHexToBinary(hexNumber);

            Console.WriteLine(binaryNumber);
        }
    }
}
