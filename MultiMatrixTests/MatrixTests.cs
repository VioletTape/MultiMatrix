using System.Drawing;
using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests {
    [TestFixture]
    public class MatrixTests {
        [Test]
        public void CouldGetValItemByPoint() {
            var matrix = new Matrix<int>(new Size(5, 5));

            matrix[new Point(1, 1)]
                    .Should()
                    .Be(0);
        }

        [Test]
        public void CouldGetRefItemByPoint() {
            var matrix = new Matrix<TestClass>(new Size(5, 5));

            matrix[new Point(1, 1)]
                    .Should()
                    .BeNull();
        }

        public class TestClass { }
    }
}
