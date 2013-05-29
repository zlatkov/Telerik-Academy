namespace _2.PersonManager
{
    using System;
    using System.Linq;

    class PersonManager
    {
        enum Gender { Male, Female };

        class Person
        {
            public Gender Gender { get; set; }
            public String Name { get; set; }
            public int Age { get; set; }
        }

        public void MakePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "Brotha";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Chicka";
                newPerson.Gender = Gender.Female;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
