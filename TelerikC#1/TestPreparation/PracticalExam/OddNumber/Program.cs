using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long xorNumber = 0l;
            long tmp;

            for (int i = 0; i < n; ++i)
            {
                xorNumber ^= long.Parse(Console.ReadLine());
            }

            Console.WriteLine(xorNumber);
        }
    }
}
