using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadRight
{
    class PadRight
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = s.PadRight(20, '*');

            Console.WriteLine(result);
        }
    }
}
