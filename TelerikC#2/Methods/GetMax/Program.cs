using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMax
{
    class Program
    {
        static int GetMax(int x, int y)
        {
            return (x > y) ? x : y;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int maximum = GetMax(a, GetMax(b, c));
            Console.WriteLine(maximum);
        }
    }
}
