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

        [Test]
        public void FillExpandedPartsWithSameFunction_Right() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(5,5));

            // act 
            map.FillWith((x, y) => x * y);
            map.CreateNewAt(Side.Right);

            // assert
            map[new Point(6, 0)].Should()
                                .Be(0);
            map[new Point(6, 1)].Should()
                                .Be(6);
            map[new Point(6, 4)].Should()
                                .Be(24);
        }

        [Test]
        public void FillExpandedPartsWithSameFunction_Left() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(5,5));

            // act 
            map.FillWith((x, y) => x * y);
            map.CreateNewAt(Side.Left);

            // assert
            map[new Point(-2, 0)].Should()
                                .Be(0);
            map[new Point(-4, 1)].Should()
                                .Be(-4);
            map[new Point(-4, 4)].Should()
                                .Be(-16);
        }

        [Test]
        public void FillExpandedPartsWithSameFunction_Top() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(5,5));

            // act 
            map.FillWith((x, y) => x * y);
            map.CreateNewAt(Side.Top);

            // assert
            map[new Point(3, 6)].Should()
                                 .Be(18);
           
        }

        [Test]
        public void FillExpandedPartsWithSameFunction_Bottom() {
            // arrange 
            var map = new MultiMatrix<int>(new Size(5,5));

            // act 
            map.FillWith((x, y) => x * y);
            map.CreateNewAt(Side.Bottom);

            // assert
            map[new Point(3, -3)].Should()
                                .Be(-9);
           
        }
    }
}
    