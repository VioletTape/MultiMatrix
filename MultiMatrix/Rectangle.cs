namespace MultiMatrix {
    public struct Rectangle {
        public readonly Point LeftTop;
        public readonly Point RightBottom;

        public Rectangle(Point leftTop, Point rightBottom) {
            this.LeftTop = leftTop;
            this.RightBottom = rightBottom;
        }

        public bool Contains(Point point) {
            return LeftTop <= point && point <= RightBottom;
        }

        public static Rectangle operator -(Rectangle rect, Point shift) {
            return new Rectangle(rect.LeftTop - shift, rect.RightBottom - shift);
        }

        public static Rectangle operator +(Rectangle rect, Point shift) {
            return new Rectangle(rect.LeftTop + shift, rect.RightBottom + shift);
        }

        public override string ToString() {
            return "{ TL= " + LeftTop + ",  BR= " + RightBottom + "}";
        }
    }
}
