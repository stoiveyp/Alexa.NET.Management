using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.UtteranceProfiler;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class UtteranceProfilerTests
    {
        [Fact]
        public async Task AnalyzeCreatesCorrectUrl()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/stages/development/interactionModel/locales/en-GB/profileNlu", req.RequestUri.PathAndQuery);
            },new UtteranceProfilerResponse()));
            var response = await management.UtteranceProfiler.Analyze("skillId",SkillStage.DEVELOPMENT,"en-GB","test");
        }
    }
}
