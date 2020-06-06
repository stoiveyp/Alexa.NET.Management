using System;
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
    }
}
