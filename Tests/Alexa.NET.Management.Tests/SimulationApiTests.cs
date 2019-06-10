using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Skills;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SimulationApiTests
    {
        [Fact]
        public void RequestSerializesCorrectly()
        {
            var request = new SimulationRequest
            {
                Device = new SimulationRequestDevice {Locale = "en-GB"},
                Input = new SimulationRequestInput {Content = "test content"},
                Session = new SimulationSession(SimulationSessionMode.FORCE_NEW_SESSION)
            };
            Assert.True(Utility.CompareJson(request, "SimulationRequest.json"));
        }
    }
}
