namespace MultiMatrix {
    public struct Rectangle {
        private readonly Point leftTop;
        private readonly Point rightBottom;

        public Rectangle(Point leftTop, Point rightBottom) {
            this.leftTop = leftTop;
            this.rightBottom = rightBottom;
        }

        public bool Contains(Point point) {
            return leftTop <= point && point <= rightBottom;
        }

        public static Rectangle operator -(Rectangle rect, Point shift) {
            return new Rectangle(rect.leftTop - shift, rect.rightBottom - shift);
        }

        public static Rectangle operator +(Rectangle rect, Point shift) {
            return new Rectangle(rect.leftTop + shift, rect.rightBottom + shift);
        }

        public override string ToString() {
            return "{ TL= " + leftTop + ",  BR= " + rightBottom + "}";
        }
    }
}
