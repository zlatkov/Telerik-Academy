using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    class Tester
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Asen", "Petrov", 3),
                new Student("Georgi", "Trifonov", 6),
                new Student("Viktor", "Stefanov", 2),
                new Student("Petur", "Jechev", 4),
                new Student("Lubomir", "Yovchev", 5),
                new Student("Biser", "Yordanov", 6), 
                new Student("Velislav", "Konstantinov", 3),
                new Student("Filip", "Haralampiev", 4),
                new Student("Ivan", "Velinov", 5),
                new Student("Konstantin", "Miroslavov", 3)
            };

            students = students.OrderBy(x => x.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.Write("\n");

            List<Worker> workers = new List<Worker>()
            {
                new Worker("workerFirstName1", "workerLastName1", 32.43m, 5),
                new Worker("workerFirstName2", "workerLastName2", 425.323m, 13),
                new Worker("workerFirstName3", "workerLastName3", 94.4392m, 8),
                new Worker("workerFirstName4", "workerLastName4", 123.456m, 4),
                new Worker("workerFirstName5", "workerLastName5", 100.2m, 1),
                new Worker("workerFirstName6", "workerLastName6", 84m, 15),
                new Worker("workerFirstName7", "workerLastName7", 4m, 1),
                new Worker("workerFirstName8", "workerLastName8", 99.99m, 7),
                new Worker("workerFirstName9", "workerLastName9", 15.15m, 2),
                new Worker("workerFirstName10", "workerLastName10", 10.1m, 10)
            };

            workers = workers.OrderBy(x => x.MoneyPerHour()).ToList();

            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }
            Console.Write("\n");

            List<Human> people = new List<Human>();

            people.AddRange(students);
            people.AddRange(workers);
            people = people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            foreach (var human in people)
            {
                Console.WriteLine(human);
            }
        }
    }
}
