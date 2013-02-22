using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrologicalDigits
{
    class Program
    {
        static int Count(string n)
        {
            int result = 0;
            for (int i = 0; i < n.Length; ++i)
            {
                if (n[i] >= '0' && n[i] <= '9')
                {
                    result += (n[i] - '0');
                }
            }
            if (result >= 10)
            {
                return Count(result.ToString());
            }
            else
            {
                return result;
            }
        }

        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            int result = Count(n);
            Console.WriteLine(result);
        }
    }
}
