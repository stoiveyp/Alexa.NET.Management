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
                var request = JsonConvert.DeserializeObject<Subscriber>(raw);
                Utility.CompareJson(request, "CreateSubscriberRequest.json");

                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                resp.Headers.Location = new Uri(responseLocation, UriKind.Relative);
                return resp;
            }));

            var subscriberRequest = new Subscriber
            {
                Name = "Example Development Event Subscriber",
                VendorId = "M123456EXAMPLE",
                Endpoint = new SubscriptionEndpoint(
                    "arn:aws:sns:us-east-2:000011122233:ExampleSNSTopic",
                    "arn:aws:iam::000011122233:role/ExampleIAMRole")
            };

            var response = await management.SkillDevelopment.Subscriber.Create(subscriberRequest);
            Assert.Equal(responseLocation, response.ToString());
        }

        [Fact]
        public async Task UpdateSubscriber()
        {
            const string requestLocation =
                "/v0/developmentEvents/subscribers/amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Put, req.Method);
                Assert.Equal(requestLocation, req.RequestUri.PathAndQuery);
                var raw = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<SubscriberUpdate>(raw);
                Utility.CompareJson(request, "CreateSubscriberRequest.json","vendorId");
            },HttpStatusCode.NoContent));

            var subscriptionRequest = new SubscriberUpdate
            {
                Name = "Example Development Event Subscriber",
                Endpoint = new SubscriptionEndpoint(
                    "arn:aws:sns:us-east-2:000011122233:ExampleSNSTopic",
                    "arn:aws:iam::000011122233:role/ExampleIAMRole")
            };

            await management.SkillDevelopment.Subscriber.Update("amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",subscriptionRequest);
        }

        [Fact]
        public Task DeleteSubscriberCorrect()
        {
            var subscriberId = "amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal($"/v0/developmentEvents/subscribers/{subscriberId}", req.RequestUri.PathAndQuery);
            },HttpStatusCode.NoContent));
      
            return management.SkillDevelopment.Subscriber.Delete(subscriberId);
        }

        [Fact]
        public Task DeleteSubscriberIncorrect()
        {
            var subscriberId = "amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Delete, req.Method);
                Assert.Equal($"/v0/developmentEvents/subscribers/{subscriberId}", req.RequestUri.PathAndQuery);
            }, HttpStatusCode.RequestTimeout));

            return Assert.ThrowsAsync<InvalidOperationException>(() => management.SkillDevelopment.Subscriber.Delete(subscriberId));
        }

        [Fact]
        public async Task GetSubscription()
        {
            const string requestLocation =
                "/v0/developmentEvents/subscribers/amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal(requestLocation, req.RequestUri.PathAndQuery);
            },Utility.ExampleFileContent<Subscriber>("CreateSubscriberRequest.json")));

            var response = await management.SkillDevelopment.Subscriber.Get("amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ListSubscriber()
        {
            const string requestLocation =
                "/v0/developmentEvents/subscribers?vendorId=vid&maxResults=10&nextToken=ABC";
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal(requestLocation, req.RequestUri.PathAndQuery);
            }, Utility.ExampleFileContent<ListSubscriberResponse>("ListSkillDevelopmentSubscribers.json")));

            var response = await management.SkillDevelopment.Subscriber.List("vid",10,"ABC");
            Assert.Equal(2,response.Links.Count);
            Assert.Equal("string",response.NextToken);
            var subscriber = Assert.Single(response.Subscribers);
            Assert.True(Utility.CompareJson(subscriber,"CreateSubscriberRequest.json","subscriberId","vendorId"));
        }

        [Fact]
        public async Task CreateSubscrption()
        {
            const string responseLocation =
                "/v0/developmentEvents/subscriptions/amzn1.ask-subscriber.xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v0/developmentEvents/subscriptions", req.RequestUri.PathAndQuery);
                var raw = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<Subscription>(raw);
                Utility.CompareJson(request, "CreateSubscriptionRequest.json");

                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                resp.Headers.Location = new Uri(responseLocation, UriKind.Relative);
                return resp;
            }));

            var subscriptionRequest = new Subscription
            {
                Name = "my subscription request",
                VendorId = "M123456EXAMPLE",
                SubscriberId = "ABC",
                Events = new[] {AlexaDevelopmentEventType.SkillPublish}
            };

            var response = await management.SkillDevelopment.Subscription.Create(subscriptionRequest);
            Assert.Equal(responseLocation, response.ToString());
        }

    }
}
