using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenCreateMatrix {
    [TestFixture]
    public class MatrixTests {
        [Test]
        public void CouldGetValItemByPoint() {
            // arrange
            var matrix = new Matrix<int>(new Size(5, 5));

            // assert
            matrix[new Point(1, 1)]
                    .Should()
                    .Be(0);
        }

        [Test]
        public void CouldGetRefItemByPoint() {
            // arrange
            var matrix = new Matrix<TestClass>(new Size(5, 5));

            // assert
            matrix[new Point(1, 1)]
                    .Should()
                    .BeNull();
        }

        [Test]
        public void BoundsShouldBeEqualToSize() {
            // arrange
            var matrix = new Matrix<TestClass>(new Size(5, 5));

            // assert
            matrix.Bound
                  .Should()
                  .Be(new Rectangle(new Point(0, 0), new Point(4, 4)));
        }

        public class TestClass { }
    }
}
