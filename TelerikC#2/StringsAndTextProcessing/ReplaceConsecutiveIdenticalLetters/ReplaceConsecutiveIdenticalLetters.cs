using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceConsecutiveIdenticalLetters
{
    class ReplaceConsecutiveIdenticalLetters
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            foreach (char symbol in s)
            {
                if (result.Length == 0 || (result.Length > 0 && result[result.Length - 1] != symbol))
                {
                    result.Append(symbol);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
