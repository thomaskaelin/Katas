namespace KataSmells.Example3Refactored
{
    public class Client
    {
        private readonly ILogger _logger;

        public Client() : this(new NullLogger())
        {

        }

        public Client(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.LogMessage("Start of DoSomething");

            // Do Something really fancy here

            _logger.LogMessage("End of DoSomething");
        }
    }
}
