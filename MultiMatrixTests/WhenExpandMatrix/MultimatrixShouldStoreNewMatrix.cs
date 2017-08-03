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
            matrix.Matricies.Count
                  .Should()
                  .Be(2);
        }

       
    }

    [TestFixture]
    public class WhenSetNewAcitveMatrix {
        [Test]
        public void WithCorrectCoordinatesItShouldChanges() {
            var matrix = new MultiMatrix<int>(new Size(5,5));

            matrix.CreateNewAt(Side.Right);
            matrix.SetActiveMatrixBy(new Point(6, 0));
            matrix.CreateNewAt(Side.Right);

            matrix.Matricies.Count
                  .Should()
                  .Be(3);
        }

        [Test]
        public void ShouldBeAbleSetPointingSide() {
            var matrix = new MultiMatrix<int>(new Size(5,5));

            matrix.CreateNewAt(Side.Right);
            matrix.SetActiveMatrixBy(Side.Right);
            matrix.CreateNewAt(Side.Right);

            matrix.Matricies.Count
                  .Should()
                  .Be(3);
        }

        [Test]
        public void IfSetSuccessfullShouldReturnTrue() {
            var matrix = new MultiMatrix<int>(new Size(5,5));

            matrix.CreateNewAt(Side.Right);

            matrix.SetActiveMatrixBy(new Point(6, 0))
                  .Should()
                  .BeTrue();
        }

        [Test]
        public void IfSetUnsuccessfullShouldReturnFalse() {
            var matrix = new MultiMatrix<int>(new Size(5,5));

            matrix.SetActiveMatrixBy(new Point(6, 0))
                  .Should()
                  .BeFalse();
        }


    }
}
