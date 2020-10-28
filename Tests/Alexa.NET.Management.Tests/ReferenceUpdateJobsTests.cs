using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ReferenceUpdateJobsTests
    {
        [Fact]
        public async Task CreateAutoRefreshJob()
        {
            var jobUrl = "/v1/skills/api/custom/interactionModel/jobs/JOB001";
            var job = new CatalogAutoRefreshJob
            {
                Resource = new CatalogResource{
                    Id = "ABCXXX",
                    Type = CatalogResourceType.Catalog
                    },
                Trigger = new CatalogScheduleTrigger
                {
                    Hour=20,
                    DayOfWeek = 0
                },
                Status = UpdateJobStatus.Enabled
            };

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<CreateUpdateJobRequest>(await req.Content.ReadAsStringAsync()), "UpdateRefCatCreateAutoRefresh.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/jobs", req.RequestUri.PathAndQuery);
                return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(jobUrl)};
            }));

            var response = await management.ReferenceCatalogManagement.UpdateJobs.Create("ABC123", job);
            Assert.Equal(jobUrl,response);
        }

        [Fact]
        public async Task CreateVersionUpdateJob()
        {
            var jobUrl = "/v1/skills/api/custom/interactionModel/jobs/JOB001";
            var job = new ReferenceVersionUpdateJob
            {
                Resource = new LocaleCatalogResource
                {
                    Id = "ABCXXX",
                    Type = CatalogResourceType.Catalog
                },
                References = new []
                {
                    new LocaleCatalogResource
                    {
                        Id = "ABCXXX",
                        Type = CatalogResourceType.Catalog
                    }
                },
                Status = UpdateJobStatus.Enabled
            };

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<CreateUpdateJobRequest>(await req.Content.ReadAsStringAsync()), "UpdateRefCatVersionUpdate.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/jobs", req.RequestUri.PathAndQuery);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(jobUrl) };
            }));

            var response = await management.ReferenceCatalogManagement.UpdateJobs.Create("ABC123", job);
            Assert.Equal(jobUrl, response);
        }

        [Fact]
        public async Task List()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/jobs?vendorId=ABC123&maxCount=10&nextToken=token", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<UpdateJobListResponse>("UpdateRefCatList.json")));

            var response = await management.ReferenceCatalogManagement.UpdateJobs.List("ABC123",10,"token");
            Assert.True(Utility.CompareJson(response,"UpdateRefCatList.json"));
        }

        [Fact]
        public async Task Delete()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/jobs/ABC123", req.RequestUri.PathAndQuery);
            },HttpStatusCode.NoContent));

            await management.ReferenceCatalogManagement.UpdateJobs.Delete("ABC123");
        }
    }
}
