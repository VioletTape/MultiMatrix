using System;

namespace MultiMatrix {
    public class MultiMatrix<T> {
        private readonly Size elementalMatrixSize;
        private Matrix<T> selectedMatrix;
        private Point zeroPointOffset;


        public MultiMatrix(Size elementalMatrixSize) {
            this.elementalMatrixSize = elementalMatrixSize;

            selectedMatrix = new Matrix<T>(elementalMatrixSize);
        }

        public T this[Point point] {
            get {
                    
                return selectedMatrix[point+zeroPointOffset];
            }
        }

        public bool SetZeroPoint(Point point, bool skipValidation) {
            zeroPointOffset = point;
            return true;
        }

        public void FillWith(Func<int, int, T> func) {
            selectedMatrix.FillWith(func);
        }
    }
}
