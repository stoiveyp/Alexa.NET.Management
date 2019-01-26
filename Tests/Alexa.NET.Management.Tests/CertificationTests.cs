using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Alexa.NET.Management.UtteranceProfiler;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class CertificationTests
    {
        [Fact]
        public async Task ListProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications", req.RequestUri.PathAndQuery);
            }, new CertificationListResponse()));
            await management.Skills.ListCertification("skillId");
        }

        [Fact]
        public async Task ListWithMaxResultsProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications?maxResults=4", req.RequestUri.PathAndQuery);
            }, new CertificationListResponse()));
            await management.Skills.ListCertification("skillId", 4);
        }

        [Fact]
        public async Task ListWithMaxResultsAndTokenProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications?maxResults=4&nextToken=abc", req.RequestUri.PathAndQuery);
            }, new CertificationListResponse()));
            await management.Skills.ListCertification("skillId", 4, "abc");
        }

        [Fact]
        public async Task CertificateProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications/certid", req.RequestUri.PathAndQuery);
            }, new Certification()));
            await management.Skills.Certification("skillId", "certid");
        }

        [Fact]
        public async Task CertificateWithLocaleProducesCorrectRequest()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/certifications/certid", req.RequestUri.PathAndQuery);
                Assert.Equal("ja-JP", req.Headers.AcceptLanguage.First().Value);
            }, new Certification()));
            await management.Skills.Certification("skillId", "certid", "ja-JP");
        }

        [Fact]
        public void CertificationListResponseDeserializesCorrectly()
        {
            var response = Utility.ExampleFileContent<CertificationListResponse>("CertificationList.json");

            Assert.Equal(2, response.Links.Count);
            Assert.False(response.IsTruncated);
            Assert.Equal("string", response.NextToken);
            Assert.Equal(1, response.TotalCount);

            var summary = Assert.Single(response.Items);
            Assert.Equal("string", summary.Id);
            Assert.Equal(CertificationStatus.InProgress, summary.Status);
        }

        [Fact]
        public void CertificationResponseDeserializesCorrectly()
        {
            var summary = Utility.ExampleFileContent<Certification>("Certification.json");
            Assert.Equal("string", summary.Id);
            Assert.Equal(CertificationStatus.InProgress, summary.Status);

            var update = Assert.Single(summary.ReviewTracking.EstimationUpdates);
            Assert.Equal("string", update.Reason);
            var country = Assert.Single(summary.Result.DistributionInformation.PublishedCountries);
            Assert.Equal("string", country);
            var failure = Assert.Single(summary.Result.DistributionInformation.PublicationFailures);
            Assert.Equal("string",failure.Reason);
            Assert.Equal("string",failure.Countries.First());
        }
    }
}
