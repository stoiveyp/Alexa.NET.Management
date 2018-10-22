using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Package;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class PackageTests
    {
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
            Assert.Equal("https://aws.amazon.com/someabsolutepath",response.UploadUri.ToString());
            Assert.Equal("2018-10-11T19:28:34.5250000Z",response.ExpiresAt.ToUniversalTime().ToString("O"));
        }

        [Fact]
        public async Task UploadUrlThrowsOnNon201()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK))));
            await Assert.ThrowsAsync<InvalidOperationException>(() => management.Package.CreateUpload());
        }
    }
}
