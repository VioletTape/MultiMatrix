using FluentAssertions;
using NUnit.Framework;
using MultiMatrix;

namespace MultiMatrixTests.RelativeCoordTests {
    [TestFixture]
    public class SetZeroPointTests {
        [Test]
        public void ZeroPointByDefaultIs00() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(9,9));
            map.FillWith((x,y) => x+y);

            // assert
            map[new Point(1, 1)].Should()
                                .Be(2);
            map[new Point(8, 8)].Should()
                                .Be(16);
        }

        [Test]
        public void ShouldUseOffsetOfZeroPoint() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(9,9));
            map.FillWith((x,y) => x+y);

            // act 
            map.SetZeroPoint(new Point(2,2), true);

            // assert
            map[new Point(1, 1)].Should()
                                .Be(6);
            map[new Point(-1, -1)].Should()
                                .Be(2);
        }
    }
}
