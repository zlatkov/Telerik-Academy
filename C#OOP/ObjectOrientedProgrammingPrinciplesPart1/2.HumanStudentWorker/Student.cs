using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, byte grade) 
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public byte Grade { private set; get; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
