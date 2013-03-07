using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Class : CommentCollection
    {
        private List<Teacher> teachers;
        private List<Student> students;
        private string id;

        public Class(string id, List<Teacher> teachers, List<Student> students)
        {
            this.id = id;
            this.teachers = teachers;
            this.students = students;
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return teachers;
            }
        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }
    }
}
