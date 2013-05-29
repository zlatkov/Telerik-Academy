using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolStystem;

namespace SchoolSystemTests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Constructor_SetNameToAlgebra()
        {
            Course course = new Course("Algebra");
            Assert.AreEqual(course.Name, "Algebra");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenNameIsNull_ShouldThrowException()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenNameIsEmpty_ShouldThrowException()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void Constructor_InitializeWithListOfStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Heather", 10001),
                new Student("Steve", 10002),
                new Student("John", 10003)
            };

            Course course = new Course("Algebra", students);
            bool studentNotFound = false;
            foreach (var student in students)
            {
                if (!course.FindStudent(student.Id))
                {
                    studentNotFound = true;
                    break;
                }
            }

            Assert.IsFalse(studentNotFound);
        }

        [TestMethod]
        public void NumberOfStudents_TestWithThreeStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Heather", 10001),
                new Student("Steve", 10002),
                new Student("John", 10003)
            };

            Course course = new Course("Algebra", students);
            Assert.AreEqual(course.NumberOfStudents, 3);
        }

        [TestMethod]
        public void FindStudent_WhenTheCourseContainsTheStudent_ShouldReturnTrue()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Heather", 10001),
                new Student("Steve", 10002),
                new Student("John", 10003)
            };

            Course course = new Course("Algebra", students);
            Assert.IsTrue(course.FindStudent(students[0].Id));
        }

        [TestMethod]
        public void FindStudent_WhenTheCourseDoesNotContainTheStudent_ShouldReturnFalse()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Heather", 10001),
                new Student("Steve", 10002),
                new Student("John", 10003)
            };

            Course course = new Course("Algebra", students);
            Assert.IsFalse(course.FindStudent(10010));
        }

        [TestMethod]
        public void AddStudent_CheckIfStudentIsAdded()
        {
            Student student = new Student("Albert", 10011);
            Course course = new Course("Algebra");
            course.AddStudent(student);

            Assert.IsTrue(course.FindStudent(student.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudent_WhenTheCourseAlreadyContainsTheStudent_ShoulThrowException()
        {
            Course course = new Course("Algebra",
                new List<Student>()
                {
                    new Student("Albert", 10011)
                });

            course.AddStudent(new Student("Albert", 10011));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudent_WhenTheNumberOfStudentsExceedThirty_ShouldThrowException()
        {
            Course course = new Course("Algebra");
            for (int i = 0; i < 31; ++i)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + i));
            }
        }

        [TestMethod]
        public void RemoveStudent_CheckIfTheStudentIsRemoved()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Heather", 10001),
                new Student("Steve", 10002),
                new Student("John", 10003)
            };

            Course course = new Course("Algebra", students);
            course.RemoveStudent(students[0].Id);

            Assert.IsFalse(course.FindStudent(students[0].Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveStudent_WhenTheCourseDoesNotContainTheStudent_ShouldThrowException()
        {
            Course course = new Course("Algebra");
            course.RemoveStudent(10001);
        }
    }
}
