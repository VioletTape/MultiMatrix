using System;
using System.Collections.Generic;

namespace MultiMatrix {
    internal class Matrix<T> {
        private readonly Size size;
       
        private readonly T[,] m;
       

        private readonly List<Matrix<T>> neighbors = new List<Matrix<T>>(4) {
                                                                                null
                                                                                , null
                                                                                , null
                                                                                , null
                                                                            };

        internal Rectangle Bound;
        internal bool IsWorldCenter;

        public Matrix(Size size) {
            this.size = size;
            Bound = new Rectangle(new Point(0,0), new Point(size.Height-1, size.Width-1));
            m = new T[size.Width, size.Height];
        }

        internal Matrix(Size size, Rectangle bound) {
            this.size = size;
            Bound = bound;
            m = new T[size.Width, size.Height];
        }

        public T this[Point point] {
            get {
                if(Bound.Contains(point))
                    return m[point.X, point.Y];

                return default(T);
            }
        } 

        public void FillWith(Func<int, int, T> func) {
            for (var x = 0; x < size.Width; x++)
            for (var y = 0; y < size.Height; y++) {
                m[x, y] = func(x, y);
            }
        }

        public bool SetNeighborAt(Side side) {
            if (neighbors[(int) side] == null) {
                neighbors[(int) side] = new Matrix<T>(size, GetBounds(side));
                return true;
            }
            return false;
        }

        public Matrix<T> GetNeighborAt(Side side) {
            return neighbors[(int) side];
        }

        private Rectangle GetBounds(Side side) {
            if (side == Side.Left) {
                return Bound - new Point(size.Width, 0);
            }

            if(side == Side.Right){
                return Bound + new Point(size.Width, 0);
            }

            if (side == Side.Top) {
                return Bound + new Point(0, size.Height);
            }

            return Bound - new Point(0, size.Height);

        }
    }
}
