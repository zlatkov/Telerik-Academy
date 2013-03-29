using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);

        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public class Teacher : ITeacher
    {
        private List<ICourse> courses;
        public string Name { set; get; }

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            result.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.courses.Count > 0)
            {
                result.Append("; Courses=[");
                bool firstPrint = true;

                foreach (var course in this.courses)
                {
                    if (!firstPrint)
                    {
                        result.Append(", ");
                    }
                    firstPrint = false;
                    result.Append(course.Name);
                }
                result.Append("]");
            }
            return result.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        public string Lab { get; set; }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            if (lab == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.Lab = lab;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} Lab={1}", base.ToString(), this.Lab);
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public string Town { set; get; }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            if (town == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.Town = town;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} Town={1}", base.ToString(), this.Town);
        }
    }

    public abstract class Course : ICourse
    {
        protected List<string> topics;

        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        protected Course(string name, ITeacher teacher)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.Name = name;
                this.Teacher = teacher;

                this.topics = new List<string>();
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            result.AppendFormat("{0}: Name={1};", this.GetType().Name, this.Name);
            
            if (this.Teacher != null)
            {
                result.AppendFormat(" Teacher={0};", this.Teacher.Name); 
            }

            if (this.topics.Count > 0)
            {
                result.Append(" Topics=[");
                bool firstToPrint = true;

                foreach (var topic in this.topics)
                {
                    if (!firstToPrint)
                    {
                        result.Append(", ");
                    }
                    result.Append(topic);
                    firstToPrint = false;
                }
                result.Append("];");
            }
            return result.ToString();
        }
    }
}
