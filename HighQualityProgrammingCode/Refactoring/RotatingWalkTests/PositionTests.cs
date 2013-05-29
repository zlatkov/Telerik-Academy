using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingWalk;

namespace RotatingWalkTests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void Constructor_WhenRowIs5()
        {
            Position position = new Position(5, 3);
            Assert.AreEqual(5, position.Row);
        }

        [TestMethod]
        public void Constructor_WhenColumnIs5()
        {
            Position position = new Position(3, 5);
            Assert.AreEqual(5, position.Column);
        }

        [TestMethod]
        public void Constructor_WithourParameters_RowShouldBeZero()
        {
            Position position = new Position();
            Assert.AreEqual(0, position.Row);
        }

        [TestMethod]
        public void Constructor_WithoutParameters_ColumnShouldBeZero()
        {
            Position position = new Position();
            Assert.AreEqual(0, position.Column);
        }

        [TestMethod]
        public void ToString_Formatting()
        {
            Position position = new Position(43, -31);
            Assert.AreEqual("43 -31", position.ToString());
        }
    }
}
