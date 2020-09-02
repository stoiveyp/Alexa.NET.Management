using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class ReferenceCatalogManagementTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<ReferenceCatalogCreationRequest>(await req.Content.ReadAsStringAsync()),"ReferenceCatalogCreate.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs", req.RequestUri.PathAndQuery);
            }, new ReferenceCatalogCreationResponse{CatalogId="testabc"}));

            var response = await management.ReferenceCatalogManagement.Create("ABC123","test","test desc");
            Assert.Equal("testabc", response.CatalogId);
        }

        [Fact]
        public async Task CreateVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Utility.CompareJson(JsonConvert.DeserializeObject<ReferenceCatalogCreateVersionRequest>(await req.Content.ReadAsStringAsync()), "ReferenceCatalogCreateVersion.json");
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/versions", req.RequestUri.PathAndQuery);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Location = new Uri("https://example.com",UriKind.Absolute);
                return resp;
            }));

            var response = await management.ReferenceCatalogManagement.CreateVersion("ABC123", "https://exampledata.com", "test desc");
            Assert.Equal("https://example.com/", response.ToString());
        }

        [Fact]
        public async void UpdateStatus()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/updateRequest/requestABC", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<ReferenceCatalogUpdateStatus>("ReferenceCatalogUpdateStatus.json")));

            var response = await management.ReferenceCatalogManagement.GetUpdateStatus("ABC123", "requestABC");
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogUpdateStatus.json"));
        }

        [Fact]
        public async Task List()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs?vendorId=vendorId&sortDirection=asc&nextToken=wibble&maxResults=10", req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(Utility.ExampleFileContent("ReferenceCatalogList.json"))
                };
                return Task.FromResult(message);
            }));
            var response = await management.ReferenceCatalogManagement.List("vendorId", SortDirection.Ascending, "wibble", 10);
            Assert.NotNull(response);
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogList.json"));
        }

        [Fact]
        public async Task ListVersions()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/catalogId/versions?sortDirection=asc&nextToken=wibble&maxResults=10", req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(Utility.ExampleFileContent("ReferenceCatalogListVersions.json"))
                };
                return Task.FromResult(message);
            }));
            var response = await management.ReferenceCatalogManagement.ListVersions("catalogId", SortDirection.Ascending, "wibble", 10);
            Assert.NotNull(response);
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogListVersions.json"));
        }

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ReferenceCatalogDefinition>("ReferenceCatalogGet.json")));

            var response = await management.ReferenceCatalogManagement.Get("ABC123");
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogGet.json"));
        }

        [Fact]
        public async Task GetVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/versions/v1", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ReferenceCatalogVersionDefinition>("ReferenceCatalogGetVersion.json")));

            var response = await management.ReferenceCatalogManagement.GetVersion("ABC123", "v1");
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogGetVersion.json"));
        }

        [Fact]
        public async Task GetValues()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/catalogs/ABC123/versions/v1/values", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ReferenceCatalogValuesResponse>("ReferenceCatalogValues.json")));

            var response = await management.ReferenceCatalogManagement.GetValues("ABC123", "v1");
            Assert.True(Utility.CompareJson(response, "ReferenceCatalogValues.json"));
        }

        [Fact]
        public void Update()
        {
            Assert.False(true);
        }

        [Fact]
        public void UpdateVersionInformation()
        {
            Assert.False(true);
        }

        [Fact]
        public void Delete()
        {
            Assert.False(true);
        }

        [Fact]
        public void DeleteVersion()
        {
            Assert.False(true);
        }
    }
}
