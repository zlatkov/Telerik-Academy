using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Tester
    {
        public class T
        {
            public virtual void P()
            {
                Console.WriteLine("P");
            }
        }

        public class T1 : T
        {
            public override void P()
            {
                Console.WriteLine("_P");
            }
        }

        static void Main(string[] args)
        {
            Student student1 = new Student("Kiril", 13);
            student1.AddComment("Test comment1 for student 1");
            student1.AddComment("Test comment2 for student 1");

            Student student2 = new Student("Vasil", 25);
            student2.AddComment("Test comment1 for student 2");
            student2.AddComment("Test comment2 for student 2");


            student1.RemoveComment("Test comment1 for student 1");
            student1.DisplayComments();

            student2.ClearComments();
            student2.DisplayComments();

            student1.AddComment("Blah blah");
            Console.WriteLine(student1.CommentsCount);
            student1.RemoveCommentAt(0);
            student1.DisplayComments();

            Discipline discipline1 = new Discipline("Discrete Mathematics", 1, 1);
            Discipline discipline2 = new Discipline("Mathematical Analysis", 1, 1);
            Discipline discipline3 = new Discipline("OOP", 2, 3);

            discipline1.AddComment("Introduction do discrete data structures.");
            discipline3.AddComment("Object Oriented Programming in C#");

            Teacher teacher1 = new Teacher("Trifon", 
                new List<Discipline>() { discipline1 });

            Teacher teacher2 = new Teacher("Grigor", 
                new List<Discipline>() { discipline2, discipline3 });

            Class class1 = new Class("312", 
                new List<Teacher>() { teacher1, teacher2} , 
                new List<Student>() { student1, student2} );

            School school = new School(new List<Class>() { class1 });
            
        }
    }
}
