using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillDevelopmentTests
    {
        [Fact]
        public void SkillUpdateSchema()
        {
            var devEvent = Utility.ExampleFileContent<SkillDevelopmentEvent>("SkillUpdateEvent.json");
            var skillUpdateEvent = Assert.IsType<SkillUpdate>(devEvent);
            Assert.Equal("aaaa-bbbb-cccc-example", skillUpdateEvent.RequestId);
            Assert.Equal(AlexaDevelopmentEventType.ManifestUpdate, skillUpdateEvent.EventName);
            Assert.Equal(skillUpdateEvent.Payload.Status, PayloadStatus.Succeeded);
            Assert.Equal("M123456EXAMPLE", skillUpdateEvent.Payload.Skill.VendorId);
            Assert.True(Utility.CompareJson(skillUpdateEvent, "SkillUpdateEvent.json", "timestamp"));
        }

        [Fact]
        public void InteractionModelUpdateSchema()
        {
            var devEvent = Utility.ExampleFileContent<SkillDevelopmentEvent>("InteractionModelEvent.json");
            var interactionModelEvent = Assert.IsType<InteractionModelUpdate>(devEvent);
            Assert.Equal("aaaa-bbbb-cccc-example", interactionModelEvent.RequestId);
            Assert.Equal(AlexaDevelopmentEventType.InteractionModelUpdate, interactionModelEvent.EventName);
            Assert.Equal(interactionModelEvent.Payload.Status, PayloadStatus.Succeeded);
            Assert.Equal("en-US", interactionModelEvent.Payload.InteractionModel.Locale);
            Assert.True(Utility.CompareJson(interactionModelEvent, "InteractionModelEvent.json","timestamp"));
        }

        [Fact]
        public async Task CreateSubscriber()
        {
            const string responseLocation =
                "/v0/developmentEvents/subscribers/amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v0/developmentEvents/subscribers", req.RequestUri.PathAndQuery);
                var raw = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<CreateSubscriptionRequest>(raw);
                Utility.CompareJson(request, "CreateSubscriptionRequest.json");

                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                resp.Headers.Location = new Uri(responseLocation, UriKind.Relative);
                return resp;
            }));

            var subscriptionRequest = new CreateSubscriptionRequest
            {
                Name = "Example Development Event Subscriber",
                VendorId = "M123456EXAMPLE",
                Endpoint = new CreateSubscriptionRequestEndpoint(
                    "arn:aws:sns:us-east-2:000011122233:ExampleSNSTopic",
                    "arn:aws:iam::000011122233:role/ExampleIAMRole")
            };

            var response = await management.SkillDevelopment.CreateSubscription(subscriptionRequest);
            Assert.Equal(responseLocation, response.ToString());
        }
    }
}
