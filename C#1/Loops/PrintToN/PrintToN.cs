using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintToN
{
    class PrintToN
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; ++i)
            {
                Console.WriteLine(i);
            }
        }
    }
}
