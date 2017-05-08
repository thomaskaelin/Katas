namespace KataSmells.Example2Refactored
{
    public class Square : Geometry
    {
        public int Length { get; set; }
        public override double Area()
        {
            return Length * Length;
        }
    }
}
