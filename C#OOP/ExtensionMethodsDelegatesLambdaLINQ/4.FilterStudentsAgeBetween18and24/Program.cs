using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentData;

namespace _4.StudentsAgeBetween18and24
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[] 
            {                                                    
                new Student("Filip", "Todorov", 22),
                new Student("Emil", "Stefanov", 19), 
                new Student("Vasil", "Ivanov", 24),
                new Student("Georgi", "Nikolov", 21),
                new Student("Petur", "Petrov", 27),
                new Student("Daniel", "Danailov", 17)
            };

            var filtered =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var student in filtered)
            {
                Console.WriteLine(student);
            }
                    

        }
    }
}
