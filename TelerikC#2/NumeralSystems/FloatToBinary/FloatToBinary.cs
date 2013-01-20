using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatToBinary
{
    class FloatToBinary
    {
        static int GetLeftNibble(byte x)
        {
            return (x >> 4);
        }

        static int GetRightNibble(byte x)
        {
            return (x & 15);
        }

        static string NibbleToBinary(int x)
        {
            string result = "";
            for (int i = 3; i >= 0; --i)
            {
                result += (x >> i) & 1;
            }

            return result;
        }

        static string ConvertFloatToBinary(float floatNumber)
        {
            string result = "";
            byte[] floatBytes = BitConverter.GetBytes(floatNumber);
            for (int i = 3; i >= 0; --i)
            {
                result += NibbleToBinary(GetLeftNibble(floatBytes[i]));
                result += NibbleToBinary(GetRightNibble(floatBytes[i]));
            }

            return result;
        }

        static void Main(string[] args)
        {
            float floatNumber = float.Parse(Console.ReadLine());

            string binaryNumber = ConvertFloatToBinary(floatNumber);

            Console.WriteLine("Binary representation: " + binaryNumber);
            Console.WriteLine("Sign: " + binaryNumber[0]);
            Console.WriteLine("Exponent: " + binaryNumber.Substring(1, 8));
            Console.WriteLine("Mantissa: " + binaryNumber.Substring(9));
        }
    }
}
