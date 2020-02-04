using System;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentSubscriptionApi
    {
        Task<Uri> Create(Subscription request);
        Task Delete(string subscriptionId);

        Task<ListedSubscription> Get(string subscriptionId);

        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId);

        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults);

        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults, string nextToken);

        Task Update(string subscriptionId, SubscriptionUpdate update);
    }
}