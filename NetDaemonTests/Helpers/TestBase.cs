using Microsoft.Extensions.DependencyInjection;

namespace NetDaemonTests.Helpers;

public class TestBase
{
    public TestContext Context = new ();
    public Entities Entities => Context.GetRequiredService<Entities>();
    public HaContextMock HaMock => Context.GetRequiredService<HaContextMock>();
    
}