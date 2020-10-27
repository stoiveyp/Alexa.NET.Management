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
    }
}
