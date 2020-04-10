using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillDevelopmentApi
    {
        [Post("/v0/developmentEvents/subscribers")]
        Task<HttpResponseMessage> CreateSubscriber([Body]Subscriber request);

        [Put("/v0/developmentEvents/subscribers/{subscriberId}")]
        Task<HttpResponseMessage> UpdateSubscriber(string subscriberId, [Body]SubscriberUpdate request);

        [Delete("/v0/developmentEvents/subscribers/{subscriberId}")]
        Task<HttpResponseMessage> DeleteSubscriber(string subscriberId);

        [Get("/v0/developmentEvents/subscribers/{subscriberId}")]
        Task<ListedSubscriber> GetSubscriber(string subscriberId);

        [Get("/v0/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId);

        [Get("/v0/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults);

        [Get("/v0/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults, string nextToken);

        [Post("/v0/developmentEvents/subscriptions")]
        Task<HttpResponseMessage> CreateSubscription([Body] Subscription request);

        [Put("/v0/developmentEvents/subscriptions/{subscriptionId}")]
        Task<HttpResponseMessage> UpdateSubscription(string subscriptionId, [Body]SubscriptionUpdate request);

        [Delete("/v0/developmentEvents/subscriptions/{subscriptionId}")]
        Task<HttpResponseMessage> DeleteSubscription(string subscriptionId);

        [Get("/v0/developmentEvents/subscriptions/{subscriptionId}")]
        Task<ListedSubscription> GetSubscription(string subscriptionId);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults, string nextToken);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId, int maxResults);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId, int maxResults, string nextToken);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId);
        
        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId, int maxResults);

        [Get("/v0/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId, int maxResults, string nextToken);
    }
}
