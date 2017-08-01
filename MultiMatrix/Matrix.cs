using System;

namespace MultiMatrix {
    internal class Matrix<T> {
        private readonly Size size;
        private T[,] m;

        public Matrix(Size size) {
            this.size = size;

            m = new T[size.Width, size.Height];
        }

        public T this[Point point] {
            get {
                return m[point.X, point.Y];
            }
        }

        public void FillWith(Func<int, int, T> func) {
            for(var x = 0; x < size.Width; x++)
            for (var y = 0; y < size.Height; y++) {
                m[x, y] = func(x, y);
            }
        }
    }
}