using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentApi:ISkillDevelopmentApi
    {
        private IClientSkillDevelopmentApi Client { get; }

        public SkillDevelopmentApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientSkillDevelopmentApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> CreateSubscriber(Subscriber request)
        {
            var response = await Client.CreateSubscriber(request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public async Task DeleteSubscriber(string subscriberId)
        {
            var response = await Client.DeleteSubscriber(subscriberId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public Task<Subscriber> GetSubscriber(string subscriberId)
        {
            return Client.GetSubscriber(subscriberId);
        }

        public Task<ListSubscriberResponse> ListSubscribers(string vendorId)
        {
            return Client.ListSubscribers(vendorId);
        }

        public Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults)
        {
            return Client.ListSubscribers(vendorId, maxResults);
        }

        public Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults, string nextToken)
        {
            return Client.ListSubscribers(vendorId, maxResults, nextToken);
        }

        public async Task UpdateSubscriber(string subscriberId, SubscriberUpdate subscriberDetails)
        {
            var response = await Client.UpdateSubscriber(subscriberId,subscriberDetails);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }
    }
}
