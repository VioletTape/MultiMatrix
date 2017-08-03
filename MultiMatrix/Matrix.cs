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

        internal bool IsWorldCenter {
            get => isWorldCenter;
            set {
                isWorldCenter = value;
                if (isWorldCenter) {
                    GetLocalCoord = p => p;
                }
                else {
                    GetLocalCoord = p => new Point(p.X - Bound.LeftTop.X, p.Y - Bound.LeftTop.Y);
                }
                   
            }
        }

        private Func<int, int, T> fillFunc = (_, __) => default(T);
        private Func<Point, Point> GetLocalCoord;
        private bool isWorldCenter;

        public Matrix(Size size) {
            this.size = size;
            Bound = new Rectangle(new Point(0, 0), new Point(size.Width - 1, size.Height - 1));
            m = new T[size.Width, size.Height];

            GetLocalCoord = p => new Point(p.X - Bound.LeftTop.X, p.Y - Bound.LeftTop.Y);
        }

        internal Matrix(Size size, Rectangle bound) {
            this.size = size;
            Bound = bound;
            m = new T[size.Width, size.Height];

            GetLocalCoord = p => new Point(p.X - Bound.LeftTop.X, p.Y - Bound.LeftTop.Y);
        }

        public T this[Point point] {
            get {
                    var targetPoint = GetLocalCoord(point);
                    return m[targetPoint.X, targetPoint.Y];
            }
            set {
                    var targetPoint = GetLocalCoord(point);
                    m[targetPoint.X, targetPoint.Y] = value;
            }
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
