using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillDevelopmentApi
    {
        [Post("/developmentEvents/subscribers")]
        Task<HttpResponseMessage> CreateSubscription([Body]CreateSubscriptionRequest request);
    }
}
