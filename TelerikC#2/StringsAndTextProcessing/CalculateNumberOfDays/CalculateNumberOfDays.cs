using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CalculateNumberOfDays
{
    class CalculateNumberOfDays
    {
        

        static void Main(string[] args)
        {
            Console.Write("Enter the first date: ");
            string firstDateString = Console.ReadLine();

            Console.Write("Enter the second date: ");
            string secondDateString = Console.ReadLine();

            DateTime firstDate = DateTime.ParseExact(firstDateString, "d.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondDateString, "d.MM.yyyy", CultureInfo.InvariantCulture);

            int numberOfDays = Math.Abs((int)firstDate.Subtract(secondDate).TotalDays); 
            Console.WriteLine("Distance: {0} days", numberOfDays);
         }
    }
}
