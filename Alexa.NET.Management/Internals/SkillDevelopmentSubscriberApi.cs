using System;
using System.Net;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentSubscriberApi:ISkillDevelopmentSubscriberApi
    {
        private IClientSkillDevelopmentApi Client;
        public SkillDevelopmentSubscriberApi(IClientSkillDevelopmentApi client)
        {
            Client = client;
        }

        public async Task<Uri> Create(Subscriber request)
        {
            var response = await Client.CreateSubscriber(request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public async Task Delete(string subscriberId)
        {
            var response = await Client.DeleteSubscriber(subscriberId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public Task<Subscriber> Get(string subscriberId)
        {
            return Client.GetSubscriber(subscriberId);
        }

        public Task<ListSubscriberResponse> List(string vendorId)
        {
            return Client.ListSubscribers(vendorId);
        }

        public Task<ListSubscriberResponse> List(string vendorId, int maxResults)
        {
            return Client.ListSubscribers(vendorId, maxResults);
        }

        public Task<ListSubscriberResponse> List(string vendorId, int maxResults, string nextToken)
        {
            return Client.ListSubscribers(vendorId, maxResults, nextToken);
        }

        public async Task Update(string subscriberId, SubscriberUpdate subscriberDetails)
        {
            var response = await Client.UpdateSubscriber(subscriberId, subscriberDetails);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }
    }
}