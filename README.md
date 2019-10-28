# CodeCube.TestFixtures.XUnit

Simple extension on the XUnit logging framework to capture everything written to the console.
This will then be displayed as output in test testresults window.

## How to use (.NET Core)
1. In the constructor for your unit test add an parameter of type ITestOutputHelper and store it in your unit test class.
2. In your unit test mock the ILoggerFactory with the following line of code `var mockLoggerFactory = new Mock<ILoggerFactory>();`
3. Add the following setup line to your mockLoggerFactory;
````loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new XunitLogger(_output));
