using MultiMatrix;
using NUnit.Framework;

namespace MultiMatrixTests.IntegrationTests {
    [TestFixture]
    [Category("Integration")]
    public class GettingValue {
        [Test]
        public void testname() {
            var matrix = new MultiMatrix<int>(new Size(500, 50));
            for (var i = 0; i < 10; i++) {
                matrix.CreateNewAt(Side.Top);
                matrix.SetActiveMatrixBy(Side.Top);
            }
        }
    }
}
