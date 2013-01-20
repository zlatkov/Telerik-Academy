using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCurrentDay
{
    class PrintCurrentDay
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is {0}.", DateTime.Today.DayOfWeek);
        }
    }
}
