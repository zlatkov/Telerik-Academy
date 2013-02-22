using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFirstNNumbers
{
    class PrintFirstNNumbers
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; ++i)
            {
                Console.WriteLine(i);
            }
        }
    }
}
