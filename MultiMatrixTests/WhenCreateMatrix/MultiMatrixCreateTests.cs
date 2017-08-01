using FluentAssertions;
using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.WhenCreateMatrix {
    [TestFixture]
    public class MultiMatrixCreateTests {
        [Test]
        public void DefaultSingleMatrixShouldBeCreated() {
            // act
            var matrix = new MultiMatrix<int>(new Size(5, 5));

            // assert
            matrix.matricies.Count
                  .Should()
                  .Be(1);
        }

        [Test]
        public void DefaultMatrixShouldBeCenterOfWorld() {
            // act
            var matrix = new MultiMatrix<int>(new Size(5, 5));

            // assert
            matrix.matricies[0].IsWorldCenter
                  .Should()
                  .BeTrue();
        }
    }
}
