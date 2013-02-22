using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetermineInputType
{
    class DetermineInputType
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool containsDigit = false;
            bool containsDot = false;
            bool containsOtherSymbols = false;

            string inputLower = input.ToLower();

            for (int i = 0; i < inputLower.Length; ++i)
            {
                switch (inputLower[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9': containsDigit = true; break;
                    case '.': containsDot = true; break;
                    default: containsOtherSymbols = true; break;
                }
            }

            if (containsOtherSymbols || input.Equals(String.Empty))
            {
                Console.WriteLine(inputLower + "*");
            }
            else if (containsDigit && containsDot)
            {
                Console.WriteLine(Convert.ToDouble(input) + 1d);
            }
            else
            {
                Console.WriteLine(Convert.ToInt32(input) + 1);
            }
        }
    }
}
