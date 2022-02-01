using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    //https://developer.amazon.com/en-US/docs/alexa/custom-skills/a-b-test-your-skill-apis.html
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

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<ExperimentDetailResponse>("ExperimentDetails.json")));

            var response = await management.Experiments.Get("ABC123", "Experiment1");
            Assert.True(Utility.CompareJson(response,"ExperimentDetails.json"));
        }

        [Fact]
        public async Task List()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments?maxResults=10&nextToken=token", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ExperimentListResponse>("ExperimentList.json")));

            var response = await management.Experiments.List("ABC123", 10, "token");
            Assert.True(Utility.CompareJson(response, "ExperimentList.json"));
        }
    }
}
