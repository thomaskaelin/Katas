namespace KataSmells.Example2Refactored
{
    public class Rectangle : Geometry
    {
        public int Width { get; set; }

        public int Height { get; set; }
        public override double Area()
        {
            return Width * Height;
        }
    }
}
