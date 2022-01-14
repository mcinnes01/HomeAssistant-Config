using System.Threading.Tasks;
using NetDaemon.Daemon.Fakes;
using Xunit;

/// <summary>
///     Tests the V2 version of app
/// </summary>
/// <remarks>
///     This test is for the V2 of the API. We are working on providing a fake library in the future for 
///     HassModel. 
/// </remarks>
public class AppTests : DaemonHostTestBase
{
    public AppTests() //: base()
    {
    }

    // [Fact]
    // public async Task CallServiceShouldCallCorrectFunction()
    // {
    //     // Add the instance of app that we run tests on
    //     // This need always need to be first operation
    //     await AddAppInstance(new HelloWorldV2App());

    //     // Init the fake NetDaemon
    //     await InitializeFakeDaemon().ConfigureAwait(false);

    //     // Add change event to simulate update in state
    //     AddChangedEvent("binary_sensor.mypir", "off", "on");

    //     // Process events and messages in fake Daemon until default timeout
    //     await RunFakeDaemonUntilTimeout().ConfigureAwait(false);

    //     // Verify that light is turned on
    //     VerifyCallService("light", "turn_on", "light.mylight");
    // }
}
