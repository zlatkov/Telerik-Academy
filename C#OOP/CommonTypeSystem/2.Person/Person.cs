using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person
{
    public class Person
    {
        public Person(string name)
            : this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { private set; get; }
        public int? Age { private set; get; }

        public override string ToString()
        {
            return String.Format("Name: {0}, age: {1}.", this.Name, (this.Age == null) ? "not specified" : this.Age.ToString());
        }
    }
}
