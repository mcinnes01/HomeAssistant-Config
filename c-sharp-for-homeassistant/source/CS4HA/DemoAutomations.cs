using System;
using System.Threading.Tasks;
using hhnl.HomeAssistantNet.Shared.Automation;
using Microsoft.Extensions.Logging;

namespace CS4HA
{
    public class DemoAutomations 
    {
        private ILogger<DemoAutomations> _logger;

        public DemoAutomations(ILogger<DemoAutomations> logger)
        {
            _logger = logger;
        }

        [Automation(runOnStart: true)]
        public void MyFirstAutomation(HomeAssistant.Entities.SunSun sun)
        {
            _logger.LogInformation($"Hello world. The sun is {sun.State}");
        }

        [Automation]
        public void LoungeMotion(HomeAssistant.)
    }
}