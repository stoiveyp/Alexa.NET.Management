using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillDevelopmentApi
    {
        [Post("/developmentEvents/subscribers")]
        Task<HttpResponseMessage> CreateSubscriber([Body]Subscriber request);

        [Put("/developmentEvents/subscribers/{subscriberId}")]
        Task<HttpResponseMessage> UpdateSubscriber(string subscriberId, [Body]SubscriberUpdate request);

        [Delete("/developmentEvents/subscribers/{subscriberId}")]
        Task<HttpResponseMessage> DeleteSubscriber(string subscriberId);

        [Get("/developmentEvents/subscribers/{subscriberId}")]
        Task<ListedSubscriber> GetSubscriber(string subscriberId);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults, string nextToken);

        [Post("/developmentEvents/subscriptions")]
        Task<HttpResponseMessage> CreateSubscription([Body] Subscription request);

        [Put("/developmentEvents/subscriptions/{subscriptionId}")]
        Task<HttpResponseMessage> UpdateSubscription(string subscriptionId, [Body]SubscriptionUpdate request);

        [Delete("/developmentEvents/subscriptions/{subscriptionId}")]
        Task<HttpResponseMessage> DeleteSubscription(string subscriptionId);

        [Get("/developmentEvents/subscriptions/{subscriptionId}")]
        Task<ListedSubscription> GetSubscription(string subscriptionId);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> List(string vendorId, string subscriberId, int maxResults, string nextToken);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId, int maxResults);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListByVendor(string vendorId, int maxResults, string nextToken);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId);
        
        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId, int maxResults);

        [Get("/developmentEvents/subscriptions")]
        Task<ListSubscriptionResponse> ListBySubscriber(string subscriberId, int maxResults, string nextToken);
    }
}
