using System;
using System.Net;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentSubscriptionApi : ISkillDevelopmentSubscriptionApi
    {
        public SkillDevelopmentSubscriptionApi(IClientSkillDevelopmentApi client)
        {
            Client = client;
        }

        private IClientSkillDevelopmentApi Client { get; set; }

        public async Task<Uri> Create(Subscription request)
        {
            var response = await Client.CreateSubscription(request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public async Task Delete(string subscriptionId)
        {
            var response = await Client.DeleteSubscription(subscriptionId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public Task<ListedSubscription> Get(string subscriptionId)
        {
            return Client.GetSubscription(subscriptionId);
        }

        public Task<ListSubscriptionResponse> List(string vendorId, string subscriberId)
        {
            if (!string.IsNullOrWhiteSpace(vendorId) && !string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.List(vendorId, subscriberId);
            }

            if (!string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.ListBySubscriber(subscriberId);
            }

            if(!string.IsNullOrWhiteSpace(vendorId))
            {
                return Client.ListByVendor(vendorId);
            }

            throw new InvalidOperationException("Please supply a vendorId, subscriberId, or both");
        }

        public Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults)
        {
            if (!string.IsNullOrWhiteSpace(vendorId) && !string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.List(vendorId, subscriberId, maxResults);
            }

            if (!string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.ListBySubscriber(subscriberId, maxResults);
            }

            if (!string.IsNullOrWhiteSpace(vendorId))
            {
                return Client.ListByVendor(vendorId, maxResults);
            }

            throw new InvalidOperationException("Please supply a vendorId, subscriberId, or both");
        }

        public Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults, string nextToken)
        {
            if (!string.IsNullOrWhiteSpace(vendorId) && !string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.List(vendorId, subscriberId, maxResults, nextToken);
            }

            if (!string.IsNullOrWhiteSpace(subscriberId))
            {
                return Client.ListBySubscriber(subscriberId, maxResults,nextToken);
            }

            if (!string.IsNullOrWhiteSpace(vendorId))
            {
                return Client.ListByVendor(vendorId, maxResults, nextToken);
            }

            throw new InvalidOperationException("Please supply a vendorId, subscriberId, or both");
        }

        public async Task Update(string subscriptionId, SubscriptionUpdate subscriptionDetails)
        {
            var response = await Client.UpdateSubscription(subscriptionId, subscriptionDetails);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }
    }
}