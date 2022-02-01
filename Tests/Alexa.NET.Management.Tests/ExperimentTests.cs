using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                Assert.True(Utility.CompareJson(JsonConvert.DeserializeObject<ExperimentRequest<Experiment>>(await req.Content.ReadAsStringAsync()), "ExperimentCreateRequest.json"));
                Assert.Equal("/v1/skills/ABC123/experiments", req.RequestUri.PathAndQuery);
                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                resp.Headers.Location = new Uri("https://example.com", UriKind.Absolute);
                return resp;
            }));

            var request = Utility.ExampleFileContent<ExperimentRequest<Experiment>>("ExperimentCreateRequest.json");
            var response = await management.Experiments.Create("ABC123",request.Experiment);
            Assert.Equal("https://example.com/",response.ToString());
        }

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<ExperimentResponse<ExperimentDetail>>("ExperimentDetails.json")));

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

        [Fact]
        public async Task Update()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.True(Utility.CompareJson(JsonConvert.DeserializeObject<ExperimentRequest<ExperimentUpdate>>(await req.Content.ReadAsStringAsync()), "ExperimentUpdateRequest.json"));
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/properties", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ExperimentResponse<Experiment>>("ExperimentUpdateResponse.json")));

            var request = Utility.ExampleFileContent<ExperimentRequest<ExperimentUpdate>>("ExperimentUpdateRequest.json");
            var response = await management.Experiments.Update("ABC123", "Experiment1", request.Experiment);
            Assert.True(Utility.CompareJson(response, "ExperimentUpdateResponse.json"));
        }

        [Fact]
        public async Task Delete()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1", req.RequestUri.PathAndQuery);
            },HttpStatusCode.NoContent));

            await management.Experiments.Delete("ABC123", "Experiment1");
        }

        [Fact]
        public async Task UpdateExposure()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/exposurePercentage", req.RequestUri.PathAndQuery);
                var jo = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.Equal(30, jo.Value<int>("exposurePercentage"));
            }, HttpStatusCode.NoContent));

            await management.Experiments.UpdateExposure("ABC123", "Experiment1",30);
        }

        [Fact]
        public async Task GetTreatmentOverrides()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/treatmentOverrides/~current", req.RequestUri.PathAndQuery);
            }, new {treatmentId="T1", treatmentOverrideCount=5}));

            var response = await management.Experiments.GetTreatmentOverride("ABC123", "Experiment1");
            Assert.Equal(TreatmentId.Treatment, response.TreatmentId);
            Assert.Equal(5, response.TreatmentOverrideCount);
        }

        [Fact]
        public async Task SetTreatmentOverrides()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/treatmentOverrides/~current", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.NoContent));

            await management.Experiments.SetTreatmentOverride("ABC123", "Experiment1", TreatmentId.Treatment);
        }

        [Fact]
        public async Task State()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/state", req.RequestUri.PathAndQuery);
            }, new{state=ExperimentState.Failed}));

            var response = await management.Experiments.State("ABC123", "Experiment1");
            Assert.Equal(ExperimentState.Failed, response.State);
        }


        [Fact]
        public async Task SetState()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/state", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.Accepted));

            await management.Experiments.State("ABC123", "Experiment1", ExperimentUpdateState.Stopped);
        }

        [Fact]
        public async Task MetricSnapshots()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/metricSnapshots", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<MetricSnapshotResponse>("ExperimentMetricSnapshotResponse.json")));

            await management.Experiments.MetricSnapshots("ABC123", "Experiment1");
        }

        [Fact]
        public async Task MetricSnapshotData()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/experiments/Experiment1/metricSnapshots/snapshot", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<MetricSnapshotData>("ExperimentMetricSnapshotData.json")));

            var response = await management.Experiments.MetricSnapshotData("ABC123", "Experiment1", "snapshot");
            Assert.True(Utility.CompareJson(response, "ExperimentMetricSnapshotData.json"));
        }
    }
}
