using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student
{
    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, string SSN, string permanentAddress,
            string mobilePhone, string email, int course, Specialties speciality, Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = SSN;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName { private get; set; }
        public string MiddleName { private get; set; }
        public string LastName { private get; set; }
        public string SSN { private get; set; }
        public string PermanentAddress { private get; set; }
        public string MobilePhone { private get; set; }
        public string Email { private get; set; }
        public int Course { private get; set; }
        public Specialties Speciality { private get; set; }
        public Universities University { private get; set; }
        public Faculties Faculty { private get; set; }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }
            else if (this.FirstName == student.FirstName &&
                this.MiddleName == student.MiddleName &&
                this.LastName == student.LastName &&
                this.SSN == student.SSN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress,
                this.MobilePhone, this.Email, this.Course, this.Speciality, this.University, this.Faculty);

        }

        public override int GetHashCode()
        {
            return this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");

            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Middle name: " + this.MiddleName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("SSN: " + this.SSN);
            result.AppendLine("Permanent address: " + this.PermanentAddress);
            result.AppendLine("Mobile phone: " + this.MobilePhone);
            result.AppendLine("Email: " + this.Email);
            result.AppendLine("Course: " + this.Course.ToString());
            result.AppendLine("Speciality: " + this.Speciality.ToString());
            result.AppendLine("University: " + this.University.ToString());
            result.AppendLine("Faculty: " + this.Faculty.ToString());

            return result.ToString();
        }

        public static bool operator ==(Student a, Student b)
        {
            return Student.Equals(a, b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !Student.Equals(a, b);
        }

        public int CompareTo(Student student)
        {
            if (!this.FirstName.Equals(student.LastName))
            {
                return this.FirstName.CompareTo(student.LastName);
            }
            else if (!this.MiddleName.Equals(student.MiddleName))
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }
            else if (!this.LastName.Equals(student.LastName))
            {
                return this.LastName.CompareTo(student.LastName);
            }
            else if (!this.SSN.Equals(student.SSN))
            {
                return this.SSN.CompareTo(student.SSN);
            }
            else
            {
                return 0;
            }
        }
    }
}
