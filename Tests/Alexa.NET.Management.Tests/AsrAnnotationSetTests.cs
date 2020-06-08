using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Asr.AnnotationSet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class AsrAnnotationSetTests
    {
        [Fact]
        public async Task Create()
        {
            var name = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/asrAnnotationSets", req.RequestUri.PathAndQuery);
                var requestcontent = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateAnnotationSetRequest>(requestcontent);
                Assert.Equal(name, request.Name);

                var json = new JObject(new JProperty("id", "abcdef")).ToString();
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json)
                };
                response.Headers.Location = new Uri("http://test.com/example", UriKind.Absolute);
                return response;
            }));

            var setresponse = await management.Asr.AnnotationSets.Create("skillId", name);
            Assert.Equal("http://test.com/example", setresponse.Location.ToString());
            Assert.Equal("abcdef", setresponse.Id);
        }

        [Fact]
        public async Task Delete()
        {
            var annotationSetId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal("/v1/skills/skillId/asrAnnotationSets/testSet", req.RequestUri.PathAndQuery);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }));

            await management.Asr.AnnotationSets.Delete("skillId", annotationSetId);
        }

        [Fact]
        public async Task GetJson()
        {
            var annotationSetId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("application/json", req.Headers.Accept.First().MediaType);
                Assert.Equal("/v1/skills/skillId/asrAnnotationSets/testSet/annotations?maxResults=10&nextToken=next", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<AnnotationSetResponse>("AsrAnnotationSet.json")));

            var response = await management.Asr.AnnotationSets.Get("skillId", annotationSetId, 10, "next");
            Assert.True(Utility.CompareJson(response,"AsrAnnotationSet.json"));
        }

        [Fact]
        public async Task GetCsv()
        {
            var annotationSetId = "testSet";

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("text/csv",req.Headers.Accept.First().MediaType);
                Assert.Equal("/v1/skills/skillId/asrAnnotationSets/testSet/annotations", req.RequestUri.PathAndQuery);
                return new HttpResponseMessage(HttpStatusCode.OK)
                    {Content = new StringContent(Utility.ExampleFileContent("AsrAnnotationSet.csv"))};
            }));

            var response = await management.Asr.AnnotationSets.GetCsv("skillId", annotationSetId);
            Assert.Equal(response, Utility.ExampleFileContent("AsrAnnotationSet.csv"));
        }
    }
}
