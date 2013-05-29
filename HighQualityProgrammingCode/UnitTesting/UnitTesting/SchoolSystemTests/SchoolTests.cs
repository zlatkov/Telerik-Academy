using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolStystem;

namespace SchoolSystemTests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void Constructor_InitializeWithListOfCourses()
        {
            var courses = new List<Course>()
            {
                new Course("Algebra", new List<Student>()
                {
                    new Student("Albert", 10001)
                })
            };

            School school = new School(courses);
            Assert.IsTrue(school.FindCourse("Algebra"));
        }

        [TestMethod]
        public void AddCourse_WhenTheCourseIsNotContainedInTheSchool()
        {
            var course = new Course("Algebra", new List<Student>()
            {
                new Student("Albert", 10001)
            });

            School school = new School();
            school.AddCourse(course);

            Assert.IsTrue(school.FindCourse(course.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCourse_WhenTheCourseIsContainedInTheSchool_ShouldThrowException()
        {

            var course = new Course("Algebra", 
                new List<Student>()
                {
                    new Student("Albert", 10001)
                });

            School school = new School(
                new List<Course>()
                {
                    course
                });

            school.AddCourse(course);
        }

        [TestMethod]
        public void RemoveCourse_WhenTheCourseIsContainedInTheSchool()
        {
            var course = new Course("Algebra",
                new List<Student>()
                {
                    new Student("Albert", 10001)
                });

            School school = new School(
                new List<Course>()
                {
                    course
                });

            school.RemoveCourse(course.Name);
            Assert.IsFalse(school.FindCourse(course.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveCourse_WhenTheCourseIsNotContainedInTheShool_ShouldThrowException()
        {
            School school = new School();
            school.RemoveCourse("Algebra");
        }
    }
}
