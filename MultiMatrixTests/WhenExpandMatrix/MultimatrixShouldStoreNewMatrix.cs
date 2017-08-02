using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenExpandMatrix {
    [TestFixture]
    public class MultimatrixShouldStoreNewMatrix {
        [Test]
        [TestCase(Side.Left)]
        [TestCase(Side.Top)]
        [TestCase(Side.Right)]
        [TestCase(Side.Bottom)]
        public void WhenEpxandIn(Side side) {
            // arrange
            var matrix = new MultiMatrix<int>(new Size(5,5));

            // act 
            matrix.CreateNewAt(side);

            // assert
            matrix.matricies.Count
                  .Should()
                  .Be(2);
        }
    }
}
