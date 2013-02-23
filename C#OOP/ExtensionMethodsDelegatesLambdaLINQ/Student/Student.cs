using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
    public struct Student 
    {
        public Student(string firstName, string lastName, int age) : this()
        {
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
        }


        public int Age { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
