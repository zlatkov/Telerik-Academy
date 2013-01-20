using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateNumberOfWorkdays
{
    class CalculateNumberOfWorkdays
    {
        static readonly List<DateTime> holidays = new List<DateTime>()
        {
            new DateTime(2013, 1, 16)
        };

        static int CalculateWorkdays(DateTime today, DateTime date)
        {
            int numberOfWorkdays = 0;
            bool isHoliday = false;

            while (today.CompareTo(date) != 1)
            {
                isHoliday = false;
                foreach (DateTime holiday in holidays)
                {
                    if (today.Equals(holiday))
                    {
                        isHoliday = true;
                        break;
                    }
                }

                if (!isHoliday && today.DayOfWeek != DayOfWeek.Saturday && today.DayOfWeek != DayOfWeek.Sunday)
                {
                    numberOfWorkdays++;
                }

                today = today.AddDays(1);
            }

            return numberOfWorkdays;
        }

        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);
            int numberOfWorkdays = CalculateWorkdays(DateTime.Today, date);
            Console.WriteLine(numberOfWorkdays);
        }
    }
}
