using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenGetPoint {
    [TestFixture]
    public class FromMultiMatrix {
        [Test]
        public void ShouldGetCorrectValueFromRightSide() {
            var matrix = new MultiMatrix<int>(new Size(5,5));
            matrix[new Point(9, 0)] = 1;
            matrix[new Point(9, 0)].Should().Be(0, "no matrix address that point");

            matrix.CreateNewAt(Side.Right);

            matrix[new Point(9, 0)] = 1;
            matrix[new Point(9, 0)].Should().Be(1, "now matrix exists at right side from original one");
        }

        [Test]
        public void ShouldGetCorrectValueFromLeftSide() {
            var matrix = new MultiMatrix<int>(new Size(5,5));
            matrix[new Point(-5, 0)] = 1;
            matrix[new Point(-5, 0)].Should().Be(0, "no matrix address that point");

            matrix.CreateNewAt(Side.Left);

            matrix[new Point(-5, 0)] = 1;
            matrix[new Point(-5, 0)].Should().Be(1, "now matrix exists at right side from original one");
        }

        [Test]
        public void ShouldGetCorrectValueFromTopSide() {
            var matrix = new MultiMatrix<int>(new Size(5,5));
            matrix[new Point(0, 9)] = 1;
            matrix[new Point(0, 9)].Should().Be(0, "no matrix address that point");

            matrix.CreateNewAt(Side.Top);

            matrix[new Point(0, 9)] = 1;
            matrix[new Point(0, 9)].Should().Be(1, "now matrix exists at right side from original one");
        }

        [Test]
        public void ShouldGetCorrectValueFromBottomSide() {
            var matrix = new MultiMatrix<int>(new Size(5,5));
            matrix[new Point(0, -5)] = 1;
            matrix[new Point(0, -5)].Should().Be(0, "no matrix address that point");

            matrix.CreateNewAt(Side.Bottom);

            matrix[new Point(0, -5)] = 1;
            matrix[new Point(0, -5)].Should().Be(1, "now matrix exists at right side from original one");
        }
    }
}
