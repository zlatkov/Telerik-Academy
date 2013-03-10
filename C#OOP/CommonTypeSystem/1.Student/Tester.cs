using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student
{
    class Tester
    {
        static void Main(string[] args)
        {
            Student a = new Student("Kiril", "Petrov", "Stefanov", "123456", "address1", "0000", "k.p.stefanov@gmail.com",
                3, Specialties.ComputerBiology, Universities.SofiaUniversity, Faculties.Biology);


            Console.WriteLine(a);

            Student b = new Student("Gavrail", "Hristov", "Gavrailov", "854380", "address2", "1111", "g.h.gavrailov@gmail.com",
                1, Specialties.Economics, Universities.UniversityOfNationalAndWorldEconomy, Faculties.Business);

            Console.WriteLine(b);

            Console.WriteLine("a == b " + (a == b));
        }
    }
}
