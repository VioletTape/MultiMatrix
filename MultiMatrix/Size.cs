namespace MultiMatrix {
    public struct Size {
        public int Width;
        public int Height;

        public Size(int width, int height) {
            Width = width;
            Height = height;
        }

        public Point AsPoint() {
            return new Point(Width, Height);
        }
    }

    
}