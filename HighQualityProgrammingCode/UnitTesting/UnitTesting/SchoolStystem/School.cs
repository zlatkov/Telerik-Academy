using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStystem
{
    public class School
    {
        private List<Course> courses;
        public School(IList<Course> courses = null)
        {
            this.courses = new List<Course>();
            if (courses != null)
            {
                foreach (var course in courses)
                {
                    this.courses.Add(course);
                }
            }
        }

        public bool FindCourse(string courseName)
        {
            return this.courses.Count(x => x.Name == courseName) > 0;
        }

        public void AddCourse(Course course)
        {
            if (this.FindCourse(course.Name))
            {
                throw new ArgumentException("The course with name: " + course.Name + " has already been added.");
            }
            this.courses.Add(course);
        }

        public void RemoveCourse(string courseName)
        {
            if (this.FindCourse(courseName))
            {
                int courseIndex = 0;
                foreach (var course in this.courses)
                {
                    if (course.Name == courseName)
                    {
                        break;
                    }
                    courseIndex++;
                }
                this.courses.RemoveAt(courseIndex);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This course hasn't been added.");
            }
        }
    }
}
