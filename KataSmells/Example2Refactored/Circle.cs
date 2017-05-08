namespace KataSmells.Example2Refactored
{
    public class Circle : Geometry
    {
        private const double Pi = 3.1415;
        public int Radius { get; set; }
        public override double Area()
        {
            return Radius * Radius * Pi;
        }
    }
}
