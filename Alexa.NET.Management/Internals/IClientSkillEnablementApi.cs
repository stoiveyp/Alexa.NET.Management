using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillEnablementApi
    {
        [Put("/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> Enable(string skillId, string stage);

        [Get("/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> CheckEnablement(string skillId, string stage);

        [Delete("/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> Disable(string skillId, string stage);
    }
}
