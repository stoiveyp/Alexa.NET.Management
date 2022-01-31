using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ExperimentTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.True(Utility.CompareJson(JsonConvert.DeserializeObject<CreateExperimentRequest>(await req.Content.ReadAsStringAsync()), "ExperimentCreateRequest.json"));
                Assert.Equal("/v1/skills/ABC123/experiments", req.RequestUri.PathAndQuery);
                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                resp.Headers.Location = new Uri("https://example.com", UriKind.Absolute);
                return resp;
            }));

            var request = Utility.ExampleFileContent<CreateExperimentRequest>("ExperimentCreateRequest.json");
            var response = await management.Experiments.Create("ABC123",request);
            Assert.Equal("https://example.com/",response.ToString());
        }
    }
}
