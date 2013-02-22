using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            decimal result = (((n * n) + (1m / (m * p)) + 1337m) / (n - 128.523123123m * p)) + (decimal)Math.Sin(((int)m) % 180);

            Console.WriteLine("{0:0.000000}", result);
        }
    }
}
