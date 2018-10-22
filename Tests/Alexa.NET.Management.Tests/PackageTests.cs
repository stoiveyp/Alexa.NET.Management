using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
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

    }
}
