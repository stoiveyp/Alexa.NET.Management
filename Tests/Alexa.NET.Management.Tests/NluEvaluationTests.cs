using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Nlu.Evaluation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class NluEvaluationTests
    {
        [Fact]
        public async Task StartEvaluationCreatesCorrectRequestAndResponse()
        {
            var locale = "en-GB";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/nluEvaluations", req.RequestUri.PathAndQuery);
                var requestcontent = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateEvaluationRequest>(requestcontent);
                Assert.Equal(locale, request.Locale);
                Assert.Equal(SkillStage.Development, request.Stage);

                var json = new JObject(new JProperty("id", "abcdef")).ToString();
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json)
                };
                response.Headers.Location = new Uri("http://test.com/example", UriKind.Absolute);
                return response;
            }));

            var setresponse = await management.Nlu.Evaluations.Create("skillId",SkillStage.Development,locale,"abcdef");
            Assert.Equal("http://test.com/example", setresponse.Location.ToString());
            Assert.Equal("abcdef", setresponse.Id);
        }

        [Fact]
        public async Task ListEvaluationCreatesCorrectRequestAndResponse()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/nluEvaluations?stage=development&maxResults=2", req.RequestUri.PathAndQuery);


            },Utility.ExampleFileContent<ListEvaluationResponse>("ListEvaluation.json")));

            var listresponse = await management.Nlu.Evaluations.List("skillId",new ListEvaulationFilters
            {
                MaxResults = 2,
                Stage = SkillStage.Development
            });

            Assert.Equal(2,listresponse.Links.Count);
            Assert.Equal("string",listresponse.PaginationContext.NextToken);
            var evaulation = Assert.Single(listresponse.Evaluations);

        }
    }
}
