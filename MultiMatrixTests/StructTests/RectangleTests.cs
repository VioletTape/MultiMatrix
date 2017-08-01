using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.StructTests {
    [TestFixture]
    public class RectangleTests {
        [Test]
        [TestCase(0,0)]
        [TestCase(0,5)]
        [TestCase(1,2)]
        [TestCase(5,0)]
        [TestCase(5,5)]
        public void ContainsPoint(int x, int y) {
            var rectangle = new Rectangle(new Point(0,0), new Point(5,5));

            rectangle.Contains(new Point(x,y))
                     .Should()
                     .BeTrue();
        }

        [Test]
        [TestCase(-1,0)]
        [TestCase(6,6)]
        [TestCase(-1,2)]
        public void NotContainsPoint(int x, int y) {
            var rectangle = new Rectangle(new Point(0,0), new Point(5,5));

            rectangle.Contains(new Point(x,y))
                     .Should()
                     .BeFalse();
        }
    }
}
