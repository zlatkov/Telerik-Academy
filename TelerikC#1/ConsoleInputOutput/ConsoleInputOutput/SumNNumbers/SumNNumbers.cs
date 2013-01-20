using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNNumbers
{
    class SumNNumbers
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int sum = 0;
            int tmpNumber;
            for (int i = 0; i < n; ++i)
            {
                tmpNumber = Convert.ToInt32(Console.ReadLine());
                sum += tmpNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
