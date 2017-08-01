using System.Drawing;
using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests {
    [TestFixture]
    public class MultiMatrixTests {
        [Test]
        public void ShouldBeAbleCreate() {
            var multiMatrix = new MultiMatrix<int>(new Size(5,5));

            multiMatrix[new Point(1, 1)]
                    .Should()
                    .Be(0);
        }
    }
}