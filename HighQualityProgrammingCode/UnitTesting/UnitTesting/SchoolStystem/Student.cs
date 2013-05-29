using System;
using System.Linq;

namespace SchoolStystem
{
    public class Student
    {
        public Student(string name, int id)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The name of the student must be nonempty.");
            }
            if (id < 10000 || id > 99999)
            {
                throw new ArgumentOutOfRangeException("The id of the student must be between 10000 and 99999.");
            }

            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
