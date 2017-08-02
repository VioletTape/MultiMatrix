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
        private Func<int, int, T> fillFunc = (_, __) => default(T);

        public Matrix(Size size) {
            this.size = size;
            Bound = new Rectangle(new Point(0, 0), new Point(size.Height - 1, size.Width - 1));
            m = new T[size.Width, size.Height];
        }

        internal Matrix(Size size, Rectangle bound) {
            this.size = size;
            Bound = bound;
            m = new T[size.Width, size.Height];
        }

        public T this[Point point] {
            get {
                if (Bound.Contains(point)) {
                    var targetPoint = GetLocalCoord(point);
                    return m[targetPoint.X, targetPoint.Y];
                }

                return default(T);
            }
            set {
                if (Bound.Contains(point)) {
                    var targetPoint = GetLocalCoord(point);
                    m[targetPoint.X, targetPoint.Y] = value;
                }
            }
        }

        private Point GetLocalCoord(Point globalCoord) {
            return IsWorldCenter
                                  ? globalCoord
                                  : new Point(globalCoord.X - Bound.LeftTop.X, globalCoord.Y - Bound.LeftTop.Y);
        }

        public void FillWith(Func<int, int, T> func) {
            fillFunc = func;
            for (int lx = 0, x = Bound.LeftTop.X; x <= Bound.RightBottom.X; x++, lx++)
            for (int ly = 0, y = Bound.LeftTop.Y; y <= Bound.RightBottom.Y; y++, ly++) {
                m[lx, ly] = func(x, y);
            }
        }

        public bool SetNeighborAt(Side side) {
            if (neighbors[(int) side] == null) {
                neighbors[(int) side] = new Matrix<T>(size, GetBounds(side));
                neighbors[(int) side].FillWith(fillFunc);
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

            if (side == Side.Right) {
                return Bound + new Point(size.Width, 0);
            }

            if (side == Side.Top) {
                return Bound + new Point(0, size.Height);
            }

            return Bound - new Point(0, size.Height);
        }
    }
}
