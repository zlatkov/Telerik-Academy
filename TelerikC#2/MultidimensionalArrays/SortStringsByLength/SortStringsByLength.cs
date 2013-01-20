using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringsByLength
{
    class SortStringsByLength
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] sequence = new string[n];
            for (int i = 0; i < n; ++i)
            {
                sequence[i] = Console.ReadLine();
            }
            Array.Sort(sequence, (x, y) => (x.Length < y.Length) ? -1 : 1);

            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(sequence[i]);
            }
        }
    }
}
