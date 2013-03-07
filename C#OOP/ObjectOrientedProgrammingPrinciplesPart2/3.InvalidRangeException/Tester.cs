using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    class Tester
    {
        static void Main(string[] args)
        {
            int startInt = int.Parse(Console.ReadLine());
            int endInt = int.Parse(Console.ReadLine());

            if (startInt > endInt)
            {
                throw new InvalidRangeException<int>("Int out of range.", startInt, endInt);
            }

            string startString = Console.ReadLine();
            string endString = Console.ReadLine();

            DateTime startDate = DateTime.Parse(startString);
            DateTime endDate = DateTime.Parse(endString);

            if (startDate.CompareTo(endDate) > 0)
            {
                throw new InvalidRangeException<DateTime>("DateTime out of range.", startDate, endDate);
            }
        }
    }
}
