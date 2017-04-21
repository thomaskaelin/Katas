namespace KataSmells.Example3
{
    public class Client
    {
        private readonly ILogger _logger;

        public Client() : this(null)
        {
        }

        public Client(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger?.LogMessage("Start of DoSomething");

            // Do Something really fancy here

            _logger?.LogMessage("End of DoSomething");
        }
    }
}
