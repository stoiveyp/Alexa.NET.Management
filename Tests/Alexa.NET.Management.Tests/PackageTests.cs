using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Package;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class PackageTests
    {
        private const string UploadPath = "https://aws.amazon.com/someabsolutepath";

        [Fact]
        public void PackageInClientNotNull()
        {
            var client = new ManagementApi("xxx");
            Assert.NotNull(client.Package);
        }

        [Fact]
        public async Task UploadUrlWorksAsExpected()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/uploads", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<PackageUploadMetadata>("PackageUpload.json"), HttpStatusCode.Created));
            var response = await management.Package.CreateUpload();
            Assert.Equal(UploadPath,response.UploadUri.ToString());
            Assert.Equal("2018-10-11T19:28:34.5250000Z",response.ExpiresAt.ToUniversalTime().ToString("O"));
        }

        [Fact]
        public async Task UploadUrlThrowsOnNon201()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK))));
            await Assert.ThrowsAsync<InvalidOperationException>(() => management.Package.CreateUpload());
        }

        [Fact]
        public async Task CreatePackageWorksAsExpected()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/imports", req.RequestUri.PathAndQuery);

                var requestObject =
                    JsonConvert.DeserializeObject<CreatePackageRequest>(await req.Content.ReadAsStringAsync());

                Assert.Equal("xxx",requestObject.VendorId);
                Assert.Equal(UploadPath, requestObject.Location);

                var message = new HttpResponseMessage(HttpStatusCode.Accepted);
                message.Headers.Location = new Uri("/v1/skills/imports/importId",UriKind.Relative);
                return message;
            }));
            var response = await management.Package.CreatePackage("xxx",UploadPath);
            Assert.NotNull(response);
            Assert.Equal("/v1/skills/imports/importId",response.ToString());
        }

        [Fact]
        public async Task CreatePackageErrorsOnNon202()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK))));
            await Assert.ThrowsAsync<InvalidOperationException>(() => management.Package.CreatePackage("xxx",UploadPath));
        }

        [Fact]
        public async Task CreatePackageThrowsOnNullVendorId()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreatePackage(null, "test"));
        }

        [Fact]
        public async Task CreatePackageThrowsOnNullLocation()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreatePackage("vendor", null));
        }

        [Fact]
        public async Task CreatePackageThrowsOnNullRequest()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreatePackage(null));
        }

        [Fact]
        public async Task CreateSkillPackageThrowsOnNullSkill()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreateSkillPackage(null,"location"));
        }

        [Fact]
        public async Task CreateSkillPackageThrowsOnNullLocation()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreateSkillPackage("skillid", ""));
        }

        [Fact]
        public async Task CreateSkillPackageCallsCorrectly()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillid/imports", req.RequestUri.PathAndQuery);

                var requestObject =
                    JsonConvert.DeserializeObject<CreateSkillPackageRequest>(await req.Content.ReadAsStringAsync());

                Assert.Equal(UploadPath, requestObject.Location);

                var message = new HttpResponseMessage(HttpStatusCode.Accepted);
                message.Headers.Location = new Uri("/v1/skills/skillid/imports/importId", UriKind.Relative);
                return message;
            }));
            var response = await management.Package.CreateSkillPackage("skillid", UploadPath);
            Assert.NotNull(response);
            Assert.Equal("/v1/skills/skillid/imports/importId", response.ToString());
        }

        [Fact]
        public void ImportStatusDeserializesCorrectly()
        {
            var importStatus = Utility.ExampleFileContent<ImportStatusResponse>("ImportStatus.json");
            Assert.Equal(ImportStatus.FAILED,importStatus.Status);
            Assert.NotNull(importStatus.Skill);

            var skill = importStatus.Skill;
            Assert.Equal("abc123",skill.SkillId);
            Assert.Equal("eTagAbc!23",skill.ETag);
            Assert.Single(skill.Resources);

            var resource = skill.Resources.First();
            Assert.Equal("resourceId",resource.Name);
            Assert.Equal(ResourceStatus.FAILED,resource.Status);
            Assert.Single(resource.Errors);
            Assert.Single(resource.Warnings);

            Assert.Equal("error 1",resource.Errors.First().Message);
            Assert.Equal("warning 1",resource.Warnings.First().Message);
        }

        [Fact]
        public async Task ImportStatusThrowsOnNullImportId()
        {
            var managementApi = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => managementApi.Package.SkillPackageStatus(null));
        }

        [Fact]
        public async Task CreateExportRequestCallsCorrectly()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillid/stages/development/exports", req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.Accepted);
                message.Headers.Location = new Uri("/v1/skills/skillid/imports/importId", UriKind.Relative);
                return Task.FromResult(message);
            }));
            var response = await management.Package.CreateExportRequest("skillid", SkillStage.development);
            Assert.NotNull(response);
            Assert.Equal("/v1/skills/skillid/imports/importId", response.ToString());
        }

        [Fact]
        public async Task CreateExportRequestThrowsNullSkillId()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.CreateExportRequest(null, SkillStage.development));
        }

        [Fact]
        public async Task ExportStatusCallsCorrectly()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/exports/exportid", req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<ExportStatusResponse>("ExportStatusResponse.json")));

            var response = await management.Package.ExportStatus("exportid");
            Assert.NotNull(response);

            Assert.Equal(ExportStatus.FAILED,response.Status);
        }

        [Fact]
        public async Task ExportStatusThrowsNullSkillId()
        {
            var management = new ManagementApi("xxx");
            await Assert.ThrowsAsync<ArgumentNullException>(() => management.Package.ExportStatus(null));
        }
    }
}
