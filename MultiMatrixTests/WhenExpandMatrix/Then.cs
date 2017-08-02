using System.Linq;
using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenExpandMatrix {
    [TestFixture]
    public class Then {
        [Test]
        [TestCase(Side.Left)]
        [TestCase(Side.Top)]
        [TestCase(Side.Right)]
        [TestCase(Side.Bottom)]
        public void CanExpandToAnySide(Side side) {
            // arrange 
            var matrix = new Matrix<int>(new Size(5,5));

            // act 
            matrix.SetNeighborAt(side)
                  .Should()
                  .BeTrue();
        }

        [Test]
        [TestCase(Side.Left)]
        [TestCase(Side.Top)]
        [TestCase(Side.Right)]
        [TestCase(Side.Bottom)]
        public void CanExpandTwice(Side side) {
            // arrange 
            var matrix = new Matrix<int>(new Size(5,5));

            // act 
            matrix.SetNeighborAt(side)
                  .Should()
                  .BeTrue();

            // assert
            matrix.SetNeighborAt(side)
                  .Should()
                  .BeFalse();
        }

        [Test]
        [TestCase(Side.Left, -5, 0)]
        [TestCase(Side.Right, 5, 0)]
        [TestCase(Side.Top, 0, 5)]
        [TestCase(Side.Bottom, 0, -5)]
        public void ShouldSetProperBounds(Side side, int x, int y) {
            // arrange 
            var matrix = new Matrix<int>(new Size(5,5));

            // act
            matrix.SetNeighborAt(side);

            // assert
            matrix.GetNeighborAt(side).Bound
                  .Should()
                  .Be(matrix.Bound + new Point(x, y));


        }

       
    }
}
