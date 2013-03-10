using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person
{
    class Tester
    {
        static void Main(string[] args)
        {
            Person a = new Person("Jimmy", 54);
            Person b = new Person("Henry");

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
