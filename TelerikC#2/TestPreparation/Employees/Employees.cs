using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Employee : IComparable<Employee>
    {
        public string firstName;
        public string secondName;
        public int rating;

        public Employee(string FirstName, string SecondName, int Rating)
        {
            firstName = FirstName;
            secondName = SecondName;
            rating = Rating;
        }

        public int CompareTo(Employee a)
        {
            if (rating != a.rating)
            {
                return -rating.CompareTo(a.rating);
            }
            else if (secondName != a.secondName)
            {
                return secondName.CompareTo(a.secondName);
            }
            else
            {
                return firstName.CompareTo(a.firstName);
            }
        }
    }

    class Employees
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> jobRating = new Dictionary<string, int>();
            for (int i = 0; i < n; ++i)
            {
                string line = Console.ReadLine();
                string[] split = line.Split(new string[] { " - " }, StringSplitOptions.None);

                if (!jobRating.ContainsKey(split[0]))
                {
                    jobRating[split[0]] = int.Parse(split[1]);
                }
            }

            List<Employee> emlpoyees = new List<Employee>();

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; ++i)
            {
                string line = Console.ReadLine();
                string[] generalSplit = line.Split(new string[]{ " - " }, StringSplitOptions.None);
                string[] names = generalSplit[0].Split(' ');

                emlpoyees.Add(new Employee(names[0], names[1], jobRating[generalSplit[1]]));
            }

            emlpoyees.Sort();
            foreach (Employee employee in emlpoyees)
            {
                Console.WriteLine("{0} {1}", employee.firstName, employee.secondName);
            }
        }
    }
}
