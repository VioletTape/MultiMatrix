﻿using System;
using System.Collections.Generic;

namespace MultiMatrix {
    public class MultiMatrix<T> {
        private Matrix<T> matrix;
        private Point zeroPointOffset;
        internal List<Matrix<T>> matricies = new List<Matrix<T>>();


        public MultiMatrix(Size elementalMatrixSize) {
            matrix = new Matrix<T>(elementalMatrixSize);
            matrix.IsWorldCenter = true;
            matricies.Add(matrix);
        }

        public T this[Point point] {
            get {
                var targetPoint = point+zeroPointOffset;
                var targetMatrix = matricies.Find(m => m.Bound.Contains(targetPoint)) ?? matrix;
                return targetMatrix[targetPoint];
            }
            set {
                var targetPoint = point+zeroPointOffset;
                var targetMatrix = matricies.Find(m => m.Bound.Contains(targetPoint)) ?? matrix;
                targetMatrix[targetPoint] = value;
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
