namespace Patterns.State
{
    public class WaterState : IState
    {
        public string Move()
        {
            return "Swim";
        }

        public string MakeNoise()
        {
            return "BluppBlupp";
        }
    }
}