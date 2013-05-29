using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolStystem;

namespace SchoolSystemTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Constructor_SetsNameToPeter()
        {
            Student student = new Student("Peter", 10001);
            Assert.AreEqual(student.Name, "Peter");
        }

        [TestMethod]
        public void Constructor_SetsIdTo10001()
        {
            Student student = new Student("Peter", 10001);
            Assert.AreEqual(student.Id, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenNameIsNull_ShoudThrowException()
        {
            Student student = new Student(null, 10030);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenNameIsEmpty_ShouldThrowException()
        {
            Student student = new Student("", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenIdIsSmallerThan10000_ShouldThrowException()
        {
            Student student = new Student("James", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenIdIsBiggerThan99999_ShouldThrowException()
        {
            Student student = new Student("James", 100000);
        }
    }
}
