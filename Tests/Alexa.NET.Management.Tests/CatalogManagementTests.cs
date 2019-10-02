using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.CatalogManagement;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class CatalogManagementTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v0/catalogs", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.Created));

            await management.CatalogManagement.Create(new CatalogCreationRequest
            {
                Title = "test title",
                Usage = "test usage",
                Type = "test type",
                VendorId = "vendorId"
            });
        }

        [Fact]
        public async Task Associate()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Put, req.Method);
                Assert.Equal("/v0/skills/skillId/catalogs/catalogId", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.Created));

            await management.CatalogManagement.Associate("skillId", "catalogId");
        }

        [Fact]
        public async Task List()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v0/catalogs?vendorId=vendor", req.RequestUri.PathAndQuery);

                var content = Utility.ExampleFileContent("CatalogList.json");
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content) };
                return Task.FromResult(responseMessage);
            }));

            var list = await management.CatalogManagement.List("vendor");
            Assert.Equal(2, list.Links.Count);
            Assert.True(list.IsTruncated);
            var catalog = Assert.Single(list.Catalogs);
            Assert.Equal("test title", catalog.Title);
            Assert.Equal(2018, catalog.LastUpdatedDate.Value.Year);
        }

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v0/catalogs/catalogId", req.RequestUri.PathAndQuery);

                var response = Utility.ExampleFileContent<CatalogListResponse>("CatalogList.json");
                var content = JObject.FromObject(response.Catalogs.First()).ToString();
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content) };
                return Task.FromResult(responseMessage);
            }));

            var catalog = await management.CatalogManagement.Get("catalogId");
            Assert.Equal("test title", catalog.Title);
            Assert.Equal(2018, catalog.LastUpdatedDate.Value.Year);
        }

        [Fact]
        public async Task Upload()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v0/catalogs/catalogId/uploads", req.RequestUri.PathAndQuery);

                var request = JObject.Parse(await req.Content.ReadAsStringAsync());
                Assert.Equal(2,request.Value<int>("numberOfUploadParts"));

                var content = Utility.ExampleFileContent("Upload.json");
                var responseMessage = new HttpResponseMessage(HttpStatusCode.Created) { Content = new StringContent(content) };
                return responseMessage;
            }));

            var upload = await management.CatalogManagement.CreateUpload("catalogId",2);
            Assert.Equal("string",upload.Id);
            var step = Assert.Single(upload.IngestionSteps);
            Assert.Single(step.Errors);
        }


    }
}
