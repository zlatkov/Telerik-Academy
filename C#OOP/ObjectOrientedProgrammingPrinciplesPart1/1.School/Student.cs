using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : Human
    {
        public Student(string name, uint classNumber) 
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber { private set; get; }
    }
}
