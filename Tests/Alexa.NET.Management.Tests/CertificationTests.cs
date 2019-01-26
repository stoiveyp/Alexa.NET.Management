using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.UtteranceProfiler;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class CertificationTests
    {
        [Fact]
        public async Task ListProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications", req.RequestUri.PathAndQuery);
            }, new UtteranceProfilerResponse()));
            await management.Skills.ListCertification("skillId");
        }

        [Fact]
        public async Task ListWithMaxResultsProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications?maxResults=4", req.RequestUri.PathAndQuery);
            }, new UtteranceProfilerResponse()));
            await management.Skills.ListCertification("skillId",4);
        }

        [Fact]
        public async Task ListWithMaxResultsAndTokenProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications?maxResults=4&nextToken=abc", req.RequestUri.PathAndQuery);
            }, new UtteranceProfilerResponse()));
            await management.Skills.ListCertification("skillId", 4,"abc");
        }
    }
}
