using FluentAssertions;
using MultiMatrix;
using MultiMatrixTests.WhenCreateMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenGetPoint {
    [TestFixture]
    public class FromMatrix {
        [Test]
        public void ItShouldReturnValueIfItWithinBound() {
            // arrange
            var map = new Matrix<int>(new Size(5,5));
            map.FillWith((x, y) => x * y + 1);

            // assert
            map[new Point(0,0)].Should().Be(0+1);
            map[new Point(1,1)].Should().Be(1+1);
            map[new Point(4,4)].Should().Be(16+1);
        }

        [Test]
        public void ItShouldReturnDefaultValueOutOfBounds() {
            // arrange
            var map = new Matrix<int>(new Size(5,5));
            map.FillWith((x, y) => x * y + 1);

            // assert
            map[new Point(-1,0)].Should().Be(0);
            map[new Point(0,-1)].Should().Be(0);
            map[new Point(5,5)].Should().Be(0);
        }
    }
}
