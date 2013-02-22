using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class Program
    {
        static string ConvertToString(List<string> list)
        {
            StringBuilder result = new StringBuilder();
            for (int i = list.Count - 1; i >= 0; --i)
            {
                result.Append(list[i]);
            }
            
            return result.ToString();
        }

        static string ConvertDigit(ulong digit)
        {
            StringBuilder result = new StringBuilder();

            ulong firstPart = digit % 26;
            ulong secondPart = digit / 26;

            if (secondPart > 0)
            {
                result.Append((char)('a' + secondPart - 1));
            }
            result.Append((char)('A' + firstPart));
            return result.ToString();
        }

        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());

            if (number == 0UL)
            {
                Console.WriteLine("A");
            }
            else
            {

                List<string> result = new List<string>();

                while (number > 0UL)
                {
                    ulong lastDigit = number % 256;
                    string stringDigit = ConvertDigit(lastDigit);

                    result.Add(stringDigit);

                    number /= 256ul;
                }

                string print = ConvertToString(result);
                Console.WriteLine(print);
            }
        }
    }
}
