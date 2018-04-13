using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Validation;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillValidationApi:ISkillValidationApi
    {
        private IClientSkillValidationApi Client { get; }

        public SkillValidationApi(HttpClient httpClient)
        {
            Client = Client = RestService.For<IClientSkillValidationApi>(httpClient);
        }

        public Task<SkillValidationResponse> Submit(string skillId, SkillStage stage)
        {
            return Client.Submit(skillId, stage);
        }

        public Task<SkillValidationResponse> Submit(string skillId, SkillStage stage, params string[] locales)
        {
            var request = new SkillValidationRequest {Locales = locales};
            return Client.Submit(skillId, stage, request);
        }

        public Task<SkillValidationResponse> Get(string skillId, SkillStage stage, string validationId)
        {
            return Client.Get(skillId, stage, validationId);
        }
    }
}
