using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { private set; get; }
        public byte WorkHoursPerDay { private set; get; }

        public decimal MoneyPerHour()
        {
            return (decimal)(this.WeekSalary / ((decimal)this.WorkHoursPerDay * 7m));
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
