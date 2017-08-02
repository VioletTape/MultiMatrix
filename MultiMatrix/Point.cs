namespace MultiMatrix {
    public struct Point {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b) {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator >(Point a, Point b) {
            return a.X > b.X && a.Y > b.Y;
        }

        public static bool operator >=(Point a, Point b) {
            return a.X >= b.X && a.Y >= b.Y;
        }

        public static bool operator <(Point a, Point b) {
            return a.X < b.X && a.Y < b.Y;
        }

        public static bool operator <=(Point a, Point b) {
            return a.X <= b.X && a.Y <= b.Y;
        }

        public override string ToString() {
            return "{x= " + X + ", y= " + Y + "}";
        }
    }
}
