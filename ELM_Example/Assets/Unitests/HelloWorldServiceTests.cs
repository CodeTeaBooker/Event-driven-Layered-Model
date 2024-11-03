using NUnit.Framework;

public class HelloWorldServiceTests
{
    [Test]
    public void GetHelloWorld_ReturnsCorrectMessage()
    {
        // Arrange
        var helloWorldService = new HelloWorldService();
        string expectedMessage = "Hello World";

        // Act
        string actualMessage = helloWorldService.GetHelloWorld();

        // Assert
        Assert.AreEqual(expectedMessage, actualMessage);
    }
}
