using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> l = new List<double>() { 1.5, 0.5, 1.0 };
            Console.WriteLine(l.Min());
            Console.WriteLine(l.Max());
            Console.WriteLine(l.Sum());
            Console.WriteLine(l.Product());
            Console.WriteLine(l.Average());
        }
    }
}
