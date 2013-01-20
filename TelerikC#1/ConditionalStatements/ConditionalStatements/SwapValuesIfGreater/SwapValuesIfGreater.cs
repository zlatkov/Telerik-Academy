using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapValuesIfGreater
{
    class SwapValuesIfGreater
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            if (a > b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }

            Console.WriteLine(a + " " + b);
        }
    }
}
