using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.FillingTests {
    [TestFixture]
    public class FillTests {
        [Test]
        public void FillWithFunc() {
            var map = new MultiMatrix<int>(new Size(5,5));
            map.FillWith((x, y) => x * y);

            map[new Point(0, 0)].Should()
                                .Be(0);
            map[new Point(1, 1)].Should()
                                .Be(1);
            map[new Point(4, 4)].Should()
                                .Be(16);

        }
    }
}
    