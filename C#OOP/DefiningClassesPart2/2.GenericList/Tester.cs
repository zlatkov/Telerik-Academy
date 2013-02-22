using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GenericList
{
    class Tester
    {
        static void Main(string[] args)
        {
            GenericList<int> l = new GenericList<int>();

            for (int i = 0; i < 1000; ++i)
            {
                l.Add(i);
            }

            Console.WriteLine(l.Max());
        }
    }
}
