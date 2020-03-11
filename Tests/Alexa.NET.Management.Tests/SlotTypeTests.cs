using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.InteractionModel;
using Alexa.NET.Management.SlotType;
using Newtonsoft.Json;
using Xunit;
using Version = Alexa.NET.Management.SlotType.Version;

namespace Alexa.NET.Management.Tests
{
    public class SlotTypeTests
    {
        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateSlotRequest>(requestBody);
                Assert.Equal("vendorid", request.VendorId);
                Assert.Equal("testslot", request.SlotType.Name);
                Assert.Equal("desc", request.SlotType.Description);
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes", req.RequestUri.PathAndQuery);
            }, new CreateSlotResponse { SlotType = new CreateSlotResponseType { Id = "ABC123" } }));
            var response = await management.SlotType.Create("vendorid", "testslot", "desc");
            Assert.Equal("ABC123", response);
        }

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Get, req.Method);
            }, new GetSlotResponse { SlotType = new SharedSlotType { Name = "testslot", Description = "desc" } }));
            var response = await management.SlotType.Get("ABC123");
            Assert.NotNull(response);
            Assert.Equal("testslot", response.Name);
            Assert.Equal("desc", response.Description);
        }

        [Fact]
        public async Task Update()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<UpdateRequest>(requestBody);
                Assert.Equal("desc2", request.SlotType.Description);
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/testslot/update", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.NoContent));
            await management.SlotType.Update("testslot", "desc2");
        }

        [Fact]
        public async Task List()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes?vendorId=ABC123&maxResults=10&sortDirection=desc", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ListSlotResponse>("ListSlotResponse.json")));
            var response = await management.SlotType.List("ABC123", 10);
            Assert.Equal(2, response.Links.Count);
            var linkedSlot = Assert.Single(response.SlotTypes);
            Assert.Single(linkedSlot.Links);
        }

        [Fact]
        public async Task Delete()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Delete, req.Method);
            }, HttpStatusCode.NoContent));
            await management.SlotType.Delete("ABC123");
        }

        [Fact]
        public async Task CreateInlineVersion()
        {
            var supplier = new InlineValueSupplier(new SlotTypeValue { Id = "seattle", Name = new SlotTypeValueName { Value = "seattle", Synonyms = new[] { "sea" } } });
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<Version>(requestBody);
                Assert.Equal("testdesc", request.SlotType.Description);
                var inline = Assert.IsType<InlineValueSupplier>(request.SlotType.Definition.ValueSupplier);
                Assert.True(Utility.CompareJson(inline, "InlineValueSupplier.json"));
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123/versions", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Post, req.Method);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Add("location", "ABC456");
                return resp;
            }));
            var code = await management.SlotType.CreateVersion("ABC123", supplier, "testdesc");
            Assert.Equal("ABC456", code);
        }

        [Fact]
        public async Task CreateCatalogVersion()
        {
            var supplier = new CatalogValueSupplier("amzn1.ask.interactionModel.catalog.123", "123");
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<Version>(requestBody);
                Assert.Equal("testdesc", request.SlotType.Description);
                var catalog = Assert.IsType<CatalogValueSupplier>(request.SlotType.Definition.ValueSupplier);
                Assert.True(Utility.CompareJson(catalog, "CatalogValueSupplier.json"));
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123/versions", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Post, req.Method);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Add("location", "ABC456");
                return resp;
            }));
            var code = await management.SlotType.CreateVersion("ABC123", supplier, "testdesc");
            Assert.Equal("ABC456", code);
        }

        [Fact]
        public async Task GetSlotVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123/versions/~current", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Get,req.Method);
            }, new CreatedVersion
            {
                SlotType = new CreatedVersionSlotType
                {
                    Version = "random",
                    Definition = new VersionDefinition
                    {
                        ValueSupplier = new CatalogValueSupplier(
                            "amzn1.ask.interactionModel.catalog.123",
                            "123")
                    }
                }
            }));
            var code = await management.SlotType.Get("ABC123", KnownVersions.Current);
            Assert.Equal("random",code.SlotType.Version);
            Assert.True(Utility.CompareJson(code.SlotType.Definition.ValueSupplier,"CatalogValueSupplier.json"));
        }

        [Fact]
        public async Task GetBuildStatus()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123/updateRequest/ABC456", req.RequestUri.PathAndQuery);
                Assert.Equal(HttpMethod.Get, req.Method);
            }, new SlotBuildStatus{UpdateRequest = new BuildStatusUpdateRequest
            {
                Status = "in progress",
                Version = "ABC123"
            }}));
            var code = await management.SlotType.BuildStatus("ABC123","ABC456");
        }

        [Fact]
        public async Task UpdateVersion()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<UpdateRequest>(requestBody);
                Assert.Equal("desc2", request.SlotType.Description);
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/testslot/versions/version/update", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.NoContent));
            await management.SlotType.Update("testslot", "version","desc2");
        }

        [Fact]
        public async Task ListVersions()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/api/custom/interactionModel/slotTypes/ABC123/versions?maxResults=10&sortDirection=desc", req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ListSlotVersionsResponse>("ListSlotVersionResponse.json")));
            var response = await management.SlotType.ListVersions("ABC123", 10);
            Assert.Equal(2, response.Links.Count);
            var linkedSlot = Assert.Single(response.SlotTypeVersions);
            Assert.Single(linkedSlot.Links);
            Assert.Equal("version",linkedSlot.Version);
            Assert.Equal("description",linkedSlot.Description);
        }

    }
}
