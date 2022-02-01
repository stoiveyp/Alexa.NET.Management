using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.KnowledgeSkill;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class KnowledgeSkillTests
    {
        [Fact]
        public async Task CreateVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<KnowledgeImportDataRequest>(await req.Content.ReadAsStringAsync()), "KnowledgeDataImport.json");
                Assert.Equal("/v1/skills/ABC123/knowledge/imports", req.RequestUri.PathAndQuery);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Location = new Uri("https://example.com", UriKind.Absolute);
                return resp;
            }));

            var response = await management.KnowledgeSkill.ImportData("ABC123", KnowledgeSkillTemplates.CompanyLocations, "CSV GOES HERE");
            Assert.Equal("https://example.com/", response.ToString());
        }

        [Fact]
        public async Task GetImport()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/knowledge/imports/ABC456", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<KnowledgeImportStatusResult>("KnowledgeImportStatus.json")));

            var response = await management.KnowledgeSkill.GetImport("ABC123", "ABC456");
            Assert.True(Utility.CompareJson(response, "KnowledgeImportStatus.json"));
        }

        [Fact]
        public async Task GetImports()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/knowledge/imports?status=IN_PROGRESS&maxResults=10&nextToken=nextToken", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<KnowledgeImportStatusResults>("KnowledgeImportStatusList.json")));

            var response = await management.KnowledgeSkill.GetImports("ABC123",KnowledgeImportDescription.InProgress, 10, "nextToken");
            Assert.True(Utility.CompareJson(response, "KnowledgeImportStatusList.json"));
        }

        [Fact]
        public async Task GetTemplateIds()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/ABC123/knowledge/templates?nextToken=nextToken&maxResults=10", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<KnowledgeTemplateIdResults>("KnowledgeTemplateList.json")));

            var response = await management.KnowledgeSkill.GetTemplateIds("ABC123",  "nextToken",10);
            Assert.True(Utility.CompareJson(response, "KnowledgeTemplateList.json"));
        }
    }
}
