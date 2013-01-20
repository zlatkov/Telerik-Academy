using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static string ConvertDecimalToBinary(int number)
        {
            String result = "";
            while (number > 0)
            {
                result = (number & 1).ToString() + result;
                number >>= 1;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string binary = ConvertDecimalToBinary(number);
            Console.WriteLine(binary);
        }
    }
}
