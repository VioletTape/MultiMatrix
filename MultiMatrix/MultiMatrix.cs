using System;
using System.Collections.Generic;

namespace MultiMatrix {
    public class MultiMatrix<T> {
        private Matrix<T> matrix;
        private Point zeroPointOffset;
        internal readonly List<Matrix<T>> Matricies = new List<Matrix<T>>();


        public MultiMatrix(Size elementalMatrixSize) {
            matrix = new Matrix<T>(elementalMatrixSize);
            matrix.IsWorldCenter = true;
            Matricies.Add(matrix);
        }

        public T this[Point point] {
            get {
                var targetPoint = point+zeroPointOffset;

//                if (matrix.Bound.Contains(targetPoint)) {
//                    return matrix[targetPoint];
//                }

                try {
                    return matrix[targetPoint];
                }
                catch (IndexOutOfRangeException e) {
                }

                matrix = Matricies.Find(m => m.Bound.Contains(targetPoint)) ?? matrix;
                return matrix[targetPoint];
            }
            set {
                var targetPoint = point+zeroPointOffset;

                try {
                    matrix[targetPoint] = value;
                    return;
                }
                catch (IndexOutOfRangeException e) {
                }

                matrix = Matricies.Find(m => m.Bound.Contains(targetPoint)) ?? matrix;
                matrix[targetPoint] = value;
            }
        }

        public bool SetZeroPoint(Point point, bool skipValidation) {
            zeroPointOffset = point;
            return true;
        }

        public bool SetActiveMatrixBy(Point point) {
            var targetmatrix = Matricies.Find(m => m.Bound.Contains(point));
            if (targetmatrix == null)
                return false;

            matrix = targetmatrix;
            return true;
        }


        public bool SetActiveMatrixBy(Side side) {
            var neighborAt = matrix.GetNeighborAt(side);
            if (neighborAt == null)
                return false;

            matrix = neighborAt;
            return true;
        }

        public bool CreateNewAt(Side side) {
            var isMatrixWasCreated = matrix.SetNeighborAt(side);
            if (isMatrixWasCreated) {
                Matricies.Add(matrix.GetNeighborAt(side));
            }

            return isMatrixWasCreated;
        }

        public void FillWith(Func<int, int, T> func) {
            matrix.FillWith(func);
        }
    }
}
