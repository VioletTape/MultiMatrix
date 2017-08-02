using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.FillingTests {
    [TestFixture]
    public class FillTests {
        [Test]
        public void FillWithFuncInitialMatrix() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(5,5));

            // act 
            map.FillWith((x, y) => x * y);

            // assert
            map[new Point(0, 0)].Should()
                                .Be(0);
            map[new Point(1, 1)].Should()
                                .Be(1);
            map[new Point(4, 4)].Should()
                                .Be(16);
        }

       
    }
}
    