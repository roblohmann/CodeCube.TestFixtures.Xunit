using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace CodeCube.TestFixtures.XUnit
{
    public sealed class XunitLogger : ILogger, IDisposable
    {
        private readonly ITestOutputHelper _output;

        public XunitLogger(ITestOutputHelper output)
        {
            _output = output;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _output.WriteLine(state.ToString());
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {
            throw new NotSupportedException("Dispose is currently not supported!");
        }
    }
}
