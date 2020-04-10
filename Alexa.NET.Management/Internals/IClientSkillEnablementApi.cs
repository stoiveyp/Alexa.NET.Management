using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillEnablementApi
    {
        [Put("/v1/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> Enable(string skillId, SkillStage stage);

        [Get("/v1/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> CheckEnablement(string skillId, SkillStage stage);

        [Delete("/v1/skills/{skillId}/stages/{stage}/enablement")]
        Task<HttpResponseMessage> Disable(string skillId, SkillStage stage);
    }
}
