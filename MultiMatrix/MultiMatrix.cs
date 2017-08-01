using System;
using System.Collections.Generic;

namespace MultiMatrix {
    public class MultiMatrix<T> {
        private readonly Size elementalMatrixSize;
        private Matrix<T> matrix;
        private Point zeroPointOffset;
        internal List<Matrix<T>> matricies = new List<Matrix<T>>();


        public MultiMatrix(Size elementalMatrixSize) {
            this.elementalMatrixSize = elementalMatrixSize;

            matrix = new Matrix<T>(elementalMatrixSize);
            matrix.IsWorldCenter = true;
            matricies.Add(matrix);
        }

        public T this[Point point] {
            get {
                return matrix[point+zeroPointOffset];
            }
        }

        public bool SetZeroPoint(Point point, bool skipValidation) {
            zeroPointOffset = point;
            return true;
        }

        public bool CreateNewAt(Side side) {
            var isMatrixWasCreated = matrix.SetNeighborAt(side);
            if (isMatrixWasCreated) {
                matricies.Add(matrix.GetNeighborAt(side));
            }

            return isMatrixWasCreated;
        }

        public void FillWith(Func<int, int, T> func) {
            matrix.FillWith(func);
        }
    }
}
