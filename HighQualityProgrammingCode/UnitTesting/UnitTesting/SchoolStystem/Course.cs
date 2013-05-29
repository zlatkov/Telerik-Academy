using System;
using System.Linq;
using System.Collections.Generic;

namespace SchoolStystem
{
    public class Course
    {
        public const int MaximumNumberOfStudents = 30;
        private List<Student> students;

        public Course(string name)
            : this(name, null)
        { }

        public Course(string name, IList<Student> students)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The name of the course must be nonempty");
            }
            this.Name = name;
            this.students = new List<Student>();

            if (students != null)
            {
                foreach (var student in students)
                {
                    this.AddStudent(student);
                }
            }
        }

        public string Name { get; private set; }
        public int NumberOfStudents
        {
            get
            {
                return this.students.Count;
            }
        }

        public bool FindStudent(int studentId)
        {
            return this.students.Count(x => x.Id == studentId) > 0;
        }

        public void AddStudent(Student student)
        {
            if (this.FindStudent(student.Id))
            {
                throw new ArgumentException("The student has already been added to the course.");
            }

            if (this.NumberOfStudents == Course.MaximumNumberOfStudents)
            {
                throw new ArgumentOutOfRangeException("The maximum number of students in a course is: " + Course.MaximumNumberOfStudents);
            }

            this.students.Add(student);
        }

        public void RemoveStudent(int studentId)
        {
            if (this.FindStudent(studentId))
            {
                int studentIndex = 0;
                foreach (var student in this.students)
                {
                    if (student.Id == studentId)
                    {
                        break;
                    }
                    studentIndex++;
                }
                this.students.RemoveAt(studentIndex);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This student hasn't been added to this course.");
            }
        }

    }
}
