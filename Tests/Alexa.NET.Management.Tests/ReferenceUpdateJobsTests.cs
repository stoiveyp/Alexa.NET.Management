using System.Net.Http;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ReferenceUpdateJobsTests
    {
        [Fact]
        public void CreateAutoRefreshJob()
        {
            var job = new CatalogAutoRefreshJob();

            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<CreateUpdateJobRequest>(await req.Content.ReadAsStringAsync()), "ReferenceCatalogCreate.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs", req.RequestUri.PathAndQuery);
            }, new ReferenceCatalogCreationResponse { CatalogId = "testabc" }));

            var response = await management.ReferenceCatalogManagement.UpdateJobs.Create("ABC123", "test", "test desc");
            Assert.Equal("testabc", response.CatalogId);
        }
    }
}
