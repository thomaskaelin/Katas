namespace Patterns.State
{
    public class AirState : IState
    {
        public string Move()
        {
            return "Fly";
        }

        public string MakeNoise()
        {
            return "Fluup";
        }
    }
}