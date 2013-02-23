using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentData;

namespace _3.StudentFirstNameBeforeLast
{
    class Program
    {
        static IEnumerable<Student> FirstNameBeforeLast(Student[] students)
        {
            IEnumerable<Student> result =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            return result;
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[] 
            {                                                    
                new Student("Filip", "Todorov", 22),
                new Student("Emil", "Stefanov", 19), 
                new Student("Vasil", "Ivanov", 24),
                new Student("Georgi", "Nikolov", 21)
            };

            IEnumerable<Student> result = FirstNameBeforeLast(students);
            foreach (Student student in result)
            {
                Console.WriteLine(student);
            }


        }
    }
}
