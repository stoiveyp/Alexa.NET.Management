using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class BetaTests
    {
        const string Email = "test@test.com";

        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/betaTest", req.RequestUri.PathAndQuery);
            },new BetaTestRequest{FeedbackEmail = Email}));
            var response = await management.Beta.Get("skillId");
        }

        [Fact]
        public async Task Create()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<BetaTestRequest>(requestBody);

                Assert.Equal(Email, request.FeedbackEmail);
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/betaTest", req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.Created);
                message.Headers.Location = new Uri("/v1/test",UriKind.Relative);
                return message;
            }));
            var response = await management.Beta.Create("skillId", Email);
            Assert.NotEqual(default,response);
        }

        [Fact]
        public async Task Update()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<BetaTestRequest>(requestBody);

                Assert.Equal(Email, request.FeedbackEmail);
                Assert.Equal(HttpMethod.Put, req.Method);
                Assert.Equal("/v1/skills/skillId/betaTest", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.NoContent));
            var response = await management.Beta.Update("skillId",Email);
            Assert.True(response);
        }

        [Fact]
        public async Task AddTesters()
        {
            var management = new ManagementApi("xxx",new ActionHandler(async req =>
            {
                var requestBody = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<TesterRequest>(requestBody);
                Assert.Single(request.Testers);
                Assert.Equal(Email, request.Testers.First().Email);
            },HttpStatusCode.NoContent));

            var response = await management.Beta.AddTesters("skillID", new[] {Email});
            Assert.True(response);
        }

        [Fact]
        public async Task GetTesters()
        {
            var management = new ManagementApi("xxx",new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get,req.Method);
                Assert.Equal("/v1/skills/skillId/betaTest/testers",req.RequestUri.PathAndQuery);

                var content = Utility.ExampleFileContent("Testers.json");
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(content)};
                return Task.FromResult(responseMessage);
            }));

            var response = await management.Beta.Testers("skillId");
            Assert.True(response.IsTruncated);
            Assert.Equal("string",response.NextToken);
            Assert.Single(response.Testers);
            Assert.Equal(Email,response.Testers.First().Email);
            Assert.True(response.Testers.First().IsReminderAllowed);
            Assert.Equal("ACCEPTED",response.Testers.First().InvitationStatus);
        }
    }
}
