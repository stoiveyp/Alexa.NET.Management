using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public void CreateVersion()
        {
            Assert.False(true);
        }

        [Fact]
        public void UpdateStatus()
        {
            Assert.False(true);
        }

        [Fact]
        public void List()
        {
            Assert.False(true);
        }

        [Fact]
        public void ListVersions()
        {
            Assert.False(true);
        }

        [Fact]
        public void Get()
        {
            Assert.False(true);
        }

        [Fact]
        public void GetVersion()
        {
            Assert.False(true);
        }

        [Fact]
        public void GetValues()
        {
            Assert.False(true);
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
