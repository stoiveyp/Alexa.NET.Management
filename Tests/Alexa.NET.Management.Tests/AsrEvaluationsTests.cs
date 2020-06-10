using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Asr.Evaluations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class AsrEvaluationsTests
    {
        [Fact]
        public async Task Run()
        {
            var locale = "en-GB";
            var annotationsetId = "abcdef";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/asrEvaluations", req.RequestUri.PathAndQuery);
                var requestcontent = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<RunEvaluationsRequest>(requestcontent);
                Assert.Equal(annotationsetId, request.AnnotationSetId);
                Assert.Equal(SkillStage.Development, request.Skill.Stage);
                Assert.Equal(locale, request.Skill.Locale);

                var json = new JObject(new JProperty("id", "abcdef")).ToString();
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json)
                };
                response.Headers.Location = new Uri("http://test.com/example", UriKind.Absolute);
                return response;
            }));

            var setresponse = await management.Asr.Evaluations.Run("skillId", SkillStage.Development, locale, annotationsetId);
            Assert.Equal("http://test.com/example", setresponse.Location.ToString());
            Assert.Equal("abcdef", setresponse.Id);
        }

        [Fact]
        public async Task Delete()
        {
            var evaluationId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal("/v1/skills/skillId/asrEvaluations/testSet", req.RequestUri.PathAndQuery);

                return new HttpResponseMessage(HttpStatusCode.NoContent).AsTask();
            }));

            await management.Asr.Evaluations.Delete("skillId", evaluationId);
        }

        [Fact]
        public async Task GetResults()
        {
            var evaluationId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/asrEvaluations/testSet/results?status=FAILED&maxResults=10&nextToken=ABCDEF", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<EvaluationResults>("AsrEvaluationSetResults.json")));

            var response = await management.Asr.Evaluations.GetResults("skillId", evaluationId, EvaluationResultStatus.Failed, 10, "ABCDEF");
            Assert.True(Utility.CompareJson(response, "AsrEvaluationSetResults.json", "expiryTime"));
        }

        [Fact]
        public async Task GetStatus()
        {
            var evaluationId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/asrEvaluations/testSet/status", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<EvaluationStatus>("AsrEvaluationSetStatus.json")));

            var response = await management.Asr.Evaluations.GetStatus("skillId", evaluationId);
            Assert.True(Utility.CompareJson(response, "AsrEvaluationSetStatus.json", "startTimestamp"));
        }

        [Fact]
        public async Task GetList()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/asrEvaluations?annotationSetId=abcdef&locale=en-GB&maxResults=10", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<EvaluationListResponse>("AsrEvaluationList.json")));

            var response = await management.Asr.Evaluations.List("skillId", new EvaluationListRequest
            {
                AnnotationSetId="abcdef",
                Locale="en-GB",
                MaxResults=10
            });
            Assert.True(Utility.CompareJson(response, "AsrEvaluationList.json", "startTimestamp"));
        }


    }
}