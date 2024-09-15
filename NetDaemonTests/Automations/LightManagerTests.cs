using NetDaemonTests.Helpers;
using NUnit.Framework;
namespace NetDaemonTests.Automations;

public class BrightnessControllerTests : TestBase
{
    [Test] 
    public void TestIsOccupiedState() 
    { 

        // Arrange 

        var contextMock = new Mock<IHaContext>(); 

        var loggerMock = new Mock<ILogger<BrightnessController>>(); 

        var brightnessController = new BrightnessController(contextMock.Object, loggerMock.Object); 

        // Act 

        brightnessController.Init(); 

        // Assert 

        Assert.IsTrue(brightnessController.sensorFault);  

    }  
}