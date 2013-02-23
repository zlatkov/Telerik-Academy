using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder t = new StringBuilder("Axl Rose has an IQ above the avarage.");
            StringBuilder firstPart = t.Substring(0, 12);
            StringBuilder secondPart = t.Substring(32, 5);


            Console.WriteLine(firstPart.ToString() + " " + secondPart.ToString());
        }
    }
}
