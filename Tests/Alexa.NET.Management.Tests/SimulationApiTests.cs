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

        [Fact]
        public void InProgressResponseDeserializesCorrectly()
        {
            var inProgress = Utility.ExampleFileContent<SimulationResponse>("SimulationResponseProgress.json");
            Assert.True(Utility.CompareJson(inProgress, "SimulationResponseProgress.json"));
            Assert.Equal(InvocationStatus.InProgress,inProgress.Status);
            Assert.Null(inProgress.Result);
        }

        [Fact]
        public void CompletedResponseDeserializesCorrectly()
        {
            var complete = Utility.ExampleFileContent<SimulationResponse>("SimulationResponseComplete.json");
            Assert.True(Utility.CompareJson(complete,"SimulationResponseComplete.json"));
            Assert.Equal(InvocationStatus.Successful,complete.Status);
            Assert.Null(complete.Result.Error);
            Assert.NotNull(complete.Result.AlexaExecutionInfo);
            Assert.NotNull(complete.Result.SkillExecutionInfo);
        }
    }
}
