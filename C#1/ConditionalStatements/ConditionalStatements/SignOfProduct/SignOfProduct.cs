using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfProduct
{
    class SignOfProduct
    {
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());

            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine("The product is zero.");
            }
            else
            {
                bool sign = true;
                if (a < 0)
                {
                    sign = !sign;
                }
                if (b < 0)
                {
                    sign = !sign;
                }
                if (c < 0)
                {
                    sign = !sign;
                }

                if (sign)
                {
                    Console.WriteLine('+');
                }
                else
                {
                    Console.WriteLine('-');
                }
            }
        }
    }
}
