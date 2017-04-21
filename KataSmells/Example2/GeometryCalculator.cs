namespace KataSmells.Example2
{
    public class GeometryCalculator
    {
        public double Area(Geometry g)
        {
            var c = g as Circle;
            if (c != null)
            {
                return c.R*c.R*3.1415;
            }

            var r = g as Rectangle;
            if (r != null)
            {
                return r.W*r.H;
            }

            var s = g as Square;
            if (s != null)
            {
                return s.L * s.L;
            }

            return -1;
        }
    }
}
