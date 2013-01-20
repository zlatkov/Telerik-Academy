using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PringGreaterNumber
{
    class PringGreaterNumber
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The bigger number is: {0}.", (a > b) ? a : b);
        }
    }
}
