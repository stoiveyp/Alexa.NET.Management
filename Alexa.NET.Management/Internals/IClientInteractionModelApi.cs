using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.InteractionModel;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientInteractionModelApi
    {
        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task<SkillInteractionContainer> Get(string skillId, string stage, string locale);

        [Head("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task<HttpResponseMessage> GetTag(string skillId, string stage, string locale);

        [Put("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}")]
        Task Update(string skillId, string stage, string locale, [Body]SkillInteractionContainer interaction);

        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/versions")]
        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale);

        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/versions")]
        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, SortDirection sortDirection);

        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/versions")]
        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, string nextToken, int maxResults);

        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/versions")]
        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, SortDirection sortDirection, string nextToken, int maxResults);

        [Get("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/versions/{version}")]
        Task<SkillModelVersion> Version(string skillId, string stage, string locale, string version);


    }
}