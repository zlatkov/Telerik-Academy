using System;

namespace Methods
{

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsOlderThan(Student student)
        {
            bool isOlder = false;
            DateTime firstStudent = this.DateOfBirth;
            DateTime secondStudent = student.DateOfBirth;

            if (DateTime.Compare(firstStudent, secondStudent) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }

    public class PersonalInformation
    {
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Hobby { get; set; }

        public PersonalInformation(string DateOfBirth, string city = null, string hobby = null)
        {
            DateTime outParamBirthDate;
            if (!DateTime.TryParse(DateOfBirth, out outParamBirthDate))
            {
                throw new FormatException("Incorrect Date format! Suggest to (15.04.1999)");
            }

            this.DateOfBirth = outParamBirthDate;
            this.City = city;
            this.Hobby = hobby;
        }
    }
}
