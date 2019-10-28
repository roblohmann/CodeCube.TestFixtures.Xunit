using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace CodeCube.TestFixtures.XUnit.Tests
{
    public class XunitLoggerTest
    {
        private readonly ITestOutputHelper _output;

        public XunitLoggerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestLogoutputCaptured()
        {
            //Setup
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new XunitLogger(_output));

            var something = new Something(mockLoggerFactory.Object);

            //Act
            something.LogSomething();

            //Assert
            Assert.NotNull(something);
        }
    }
}
