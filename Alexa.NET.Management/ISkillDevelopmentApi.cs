using System;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentApi
    {
        Task<Uri> CreateSubscriber(Subscriber request);
        Task DeleteSubscriber(string subscriberId);
        Task<Subscriber> GetSubscriber(string subscriberId);

        Task<ListSubscriberResponse> ListSubscribers(string vendorId);

        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults);

        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults, string nextToken);
    }
}
