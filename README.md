# CodeCube.TestFixtures.Xunit

Simple extension on the XUnit logging framework to capture everything written to the console.
This will then be displayed as output in test testresults window.

## How to use (.NET Core)
1. In the constructor for your unit test add an parameter of type ITestOutputHelper and store it in your unit test class.
2. In your unit test mock the ILoggerFactory with the following line of code;
    ```C#
    var mockLoggerFactory = new Mock<ILoggerFactory>();
    ```
3. Add the following setup line to your mockLoggerFactory;
    ```C#
    mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(new XunitLogger(_output));
    ```
4. That's it! Once the test has run, you can click the link saying 'Open additional output for this result'. And it will show the log lines.

### Full example
**The class being tested**

```C# - Tested class
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
```

**The unit test, using the Moq framework**

``` C# - Unit test
public class TestSomething()
{
    private ITestOutputHelper _output;    
    public TestSomething(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task() TheTest()
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
```

**The result**
![alt test](https://github.com/roblohmann/CodeCube.TestFixtures.XUnit/blob/master/CodeCube.TestFixtures.XUnit.Tests/result.PNG?raw=true "The result after implementation")
