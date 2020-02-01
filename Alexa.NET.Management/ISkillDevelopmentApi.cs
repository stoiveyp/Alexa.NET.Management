using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentApi
    {
        [Post("/developmentEvents/subscribers")]
        Task<HttpResponseMessage> Get([Body]CreateSubscriptionRequest request);
    }
}
