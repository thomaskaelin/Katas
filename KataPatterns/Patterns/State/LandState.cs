namespace Patterns.State
{
    public class LandState : IState
    {
        public string Move()
        {
            return "Run";
        }

        public string MakeNoise()
        {
            return "Wuaaaaa";
        }
    }
}