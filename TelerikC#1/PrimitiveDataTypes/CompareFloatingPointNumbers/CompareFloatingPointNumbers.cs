using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareFloatingPointNumbers
{
    class CompareFloatingPointNumbers
    {
        static void Main(string[] args)
        {
            const double Eps = 1e-6;

            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());

            bool result = (Math.Abs(a - b) < Eps);
            Console.WriteLine(result.ToString());
        }
    }
}
