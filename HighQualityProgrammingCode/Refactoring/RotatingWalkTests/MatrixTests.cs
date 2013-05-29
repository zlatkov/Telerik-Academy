using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingWalk;

namespace RotatingWalkTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenDimensionIsZero_ShouldThrowException()
        {
            Matrix matrix = new Matrix(-4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenDImensionIs101_ShouldThrowException()
        {
            Matrix matrix = new Matrix(101);
        }

        [TestMethod]
        public void Constructor_WhenDimensionIs5()
        {
            Matrix matrix = new Matrix(5);
            Assert.AreEqual(5, matrix.Dimension);
        }

        [TestMethod]
        public void Traverse_WhenDimensionIs1()
        {
            Matrix matrix = new Matrix(1);
            matrix.Traverse();

            Assert.AreEqual("1", matrix.ToString());
        }

        [TestMethod]
        public void Traverse_WhenDimensionIs2()
        {
            Matrix matrix = new Matrix(2);
            matrix.Traverse();

            Assert.AreEqual("1 4\n" + 
                            "3 2", matrix.ToString());
        }

        [TestMethod]
        public void Traverse_WhenDimensionIs6()
        {
            Matrix matrix = new Matrix(6);
            matrix.Traverse();

            Assert.AreEqual("1 16 17 18 19 20\n" +
                            "15 2 27 28 29 21\n" +
                            "14 31 3 26 30 22\n" +
                            "13 36 32 4 25 23\n" +
                            "12 35 34 33 5 24\n" +
                            "11 10 9 8 7 6", matrix.ToString());
        }
    }
}
