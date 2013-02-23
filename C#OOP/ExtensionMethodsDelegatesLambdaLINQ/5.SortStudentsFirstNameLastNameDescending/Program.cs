using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentData;

namespace _5.SortStudentsFirstNameLastNameDescending
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {                                                    
                new Student("Filip", "Todorov", 22),
                new Student("Emil", "Stefanov", 19),
                new Student("Filip", "Kostadinov", 18),
                new Student("Vasil", "Ivanov", 24),
                new Student("Georgi", "Nikolov", 21),
                new Student("Petur", "Petrov", 27),
                new Student("Daniel", "Danailov", 17)
            };

            var sorterWithLambda = students.
                OrderByDescending(student => student.FirstName).
                ThenByDescending(student => student.LastName);

            foreach (Student student in sorterWithLambda)
            {
                Console.WriteLine(student);
            }

            Console.Write("\n");

            var sortedWithLinq =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            foreach (Student student in sortedWithLinq)
            {
                Console.WriteLine(student);
            }

        }
    }
}
