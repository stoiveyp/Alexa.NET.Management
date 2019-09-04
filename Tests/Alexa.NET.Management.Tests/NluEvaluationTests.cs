using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.NluEvaluation;
using Alexa.NET.Management.UtteranceProfiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class NluEvaluationTests
    {
        [Fact]
        public async Task CreateEvaluationSetGeneratesCorrectRequest()
        {
            var locale = "en-GB";
            var name = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/nluAnnotationSets", req.RequestUri.PathAndQuery);
                var requestcontent = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateAnnotationSetRequest>(requestcontent);
                Assert.Equal(locale,request.Locale);
                Assert.Equal(name,request.Name);

                var json = new JObject(new JProperty("id", "abcdef")).ToString();
                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(json)
                };
                response.Headers.Location = new Uri("http://test.com/example", UriKind.Absolute);
                return response;
            }));

            var setresponse = await management.NluEvaluation.CreateAnnotationSet("skillId", locale, name);
            Assert.Equal("http://test.com/example",setresponse.Location.ToString());
            Assert.Equal("abcdef",setresponse.Id);
        }
    }
}
