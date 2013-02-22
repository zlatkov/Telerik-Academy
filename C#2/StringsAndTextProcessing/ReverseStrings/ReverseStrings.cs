using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    class ReverseStrings
    {
        static string ReverseString(string a)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; --i)
            {
                sb.Append(a[i]);
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string reversed = ReverseString(a);
            Console.WriteLine(reversed);
        }
    }
}
