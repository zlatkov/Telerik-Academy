using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CalculateNewDate
{
    class CalculateNewDate
    {
        static void Main(string[] args)
        {
            string dateString = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            date = date.AddHours(6.5);

            Console.WriteLine("{0} {1}", date.ToString(), date.ToString("dddd", new CultureInfo("bg-BG")));
        }
    }
}
