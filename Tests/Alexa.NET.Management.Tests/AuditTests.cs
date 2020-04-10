using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Audit;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class AuditTests
    {
        [Fact]
        public async Task Request()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/developmentAuditLogs/query", req.RequestUri.PathAndQuery);
                var request = JsonConvert.DeserializeObject<QueryRequest>(await req.Content.ReadAsStringAsync());
                Assert.True(Utility.CompareJson(request, "AuditQueryRequest.json","startTime","endTime"));
            }, new QueryResponse()));
            await management.AuditLogs.Query(new QueryRequest
            {
                VendorId = "ABC123",
                SortDirection = SortDirection.Descending,
                SortField = SortField.Timestamp,
                PaginationContext = new PaginationContextWithMaxResults
                {
                    NextToken = "Vxjbbbbbbbbaa",
                    MaxResults = 2
                },
                RequestFilters = new RequestFilters
                {
                    StartTime = new DateTime(2019, 06, 01, 22, 58, 24),
                    EndTime = new DateTime(2019, 06, 08, 22, 58, 24),
                    HttpResponseCodes = new[] { "200", "202" },
                    Requesters = new[] { new Requester("amzn1.account.LWAUserId") },
                    Resources = new[] { new Resource("amzn1.ask.skill.1234", ResourceType.Skill), },
                    Operations = new[] { new Operation("getSkillManifest", "v1"), new Operation("getUtteranceData", "v1"), }
                }
            });
        }

        [Fact]
        public async Task Response()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {

            }, Utility.ExampleFileContent<QueryResponse>("AuditQueryResponse.json")));
            var response = await management.AuditLogs.Query(new QueryRequest());
            Assert.Equal("VXjbbbbbbbbb",response.PaginationContext.NextToken);
            Assert.Equal(2,response.AuditLogs.Length);
            var first = response.AuditLogs.First();

            Assert.Equal(HttpStatusCode.OK,first.HttpResponseCode);
            Assert.Equal("a53cbaa5-f64b-11e7-94e4-e7de641ed24a",first.AmazonRequestId);
            Assert.Equal("associateSkillWithCatalog",first.Operation.Name);
            Assert.Equal("v1", first.Operation.Version);
            Assert.Equal("amzn1.ask.skill.1234",first.Resources.First().Id);
            Assert.Equal(ResourceType.SkillCatalog,first.Resources.Skip(1).First().Type);
            Assert.Equal("amzn1.oauth.LWAUserId",first.Requester.UserId);
            Assert.Equal("amzn1.application-oa2-client.aad322b5faab44b980c8f87f94fbac56",first.Client.Id);
            Assert.Equal("Alexa Skills Kit Command Line Interface", first.Client.Name);
        }
    }
}
