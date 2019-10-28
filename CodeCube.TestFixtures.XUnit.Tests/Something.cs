using Microsoft.Extensions.Logging;

namespace CodeCube.TestFixtures.XUnit.Tests
{
    public class Something
    {
        private readonly ILogger _logger;

        public Something(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Something>();
        }

        public void LogSomething()
        {
            _logger.LogInformation("Method LogSomething has been called!"); 
        }
    }
}