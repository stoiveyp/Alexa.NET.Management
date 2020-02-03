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
        Task<Subscriber> GetSubscriber(string subscriberId);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults);

        [Get("/developmentEvents/subscribers")]
        Task<ListSubscriberResponse> ListSubscribers(string vendorId, int maxResults, string nextToken);
    }
}
