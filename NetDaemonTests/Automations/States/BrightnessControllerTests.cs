using NetDaemonTests.Helpers;
using NetDaemonApps.Automations.States;
using Microsoft.Extensions.Logging;

namespace NetDaemonTests.Automations.States
{
    public class BrightnessControllerTests : TestBase
    {

        // [Test] 
        // public void BrightnessController_Init_ShouldSetSensorFaultToTrue_WhenIlluminanceSensorStateIsNull() 
        // { 

        //     // Arrange 

        //     var contextMock = new Mock<IHaContext>(); 

        //     var loggerMock = new Mock<ILogger<BrightnessController>>(); 

        //     var brightnessController = new BrightnessController(contextMock.Object, loggerMock.Object); 

        //     // Act 

        //     brightnessController.Init(); 

        //     // Assert 

        //     Assert.IsTrue(brightnessController.sensorFault);  

        // }  

        // [Test]  
        // public void BrightnessController_Handle_ShouldSetBrightnessToDark_WhenTriggerIsSensorDark()  
        // {  

        //     // Arrange  

        //     var contextMock = new Mock<IHaContext>();  

        //     var loggerMock = new Mock<ILogger<BrightnessController>>();  

        //     var brightnessController = new BrightnessController(contextMock.Object, loggerMock.Object);  

        //     // Act  

        //     brightnessController.Handle(Trigger.SensorDark);  

        //     // Assert  

        //     Assert.AreEqual(BrightnessOptions.Dark, brightnessController?._entities?._inputSelect?._brightness?._state?._attributes?._options[0]);   										    	    	    	    	    	    	    	    	    
        // }   
    }   
}