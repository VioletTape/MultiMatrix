using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.IntegrationTests {
    [TestFixture]
    [Category("Integration")]
    public class GettingValue {
        [Test]
        public void ForProfiling() {
            var matrix = new MultiMatrix<int>(new Size(500, 50));
            for (var i = 0; i < 10; i++) {
                matrix.CreateNewAt(Side.Top);
                matrix.SetActiveMatrixBy(Side.Top);
            }

            for (int i = 0; i < 500; i++) {
                for (int j = 0; j < 500; j++) {
                    matrix[new Point(j, i)] = 1;
                } 
            }
        }
    }
}
