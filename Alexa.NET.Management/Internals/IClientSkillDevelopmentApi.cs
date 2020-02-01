using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillDevelopmentApi
    {
        [Post("/developmentEvents/subscribers")]
        Task<HttpResponseMessage> CreateSubscriber([Body]Subscription request);

        [Delete("/developmentEvents/subscribers/{subscriberId}")]
        Task<HttpResponseMessage> DeleteSubscriber(string subscriberId);
    }
}
