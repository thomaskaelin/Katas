namespace Patterns.State
{
    public class Animal
    {
        private IState _state;

        public Animal()
        {
            _state = new WaterState();
        }

        private string Move()
        {
            return _state.Move();
        }

        private string MakeNoise()
        {
            return _state.MakeNoise();
        }

        public string PerformTrick()
        {
            return Move() + MakeNoise();
        }

        public void GoFlying()
        {
            _state = new AirState();
        }

        public void GoSwimming()
        {
            _state = new WaterState();
        }

        public void GoRunning()
        {
            _state = new LandState();
        }
    }
}