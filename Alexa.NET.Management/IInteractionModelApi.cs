using System.Threading.Tasks;
using Alexa.NET.Management.InteractionModel;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management
{
    public interface IInteractionModelApi
    {
        Task<SkillInteractionContainer> Get(string skillId, string stage, string locale);

        Task<string> GetTag(string skillId, string stage, string locale);

        Task Update(string skillId, string stage, string locale, SkillInteractionContainer interaction);

        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale);

        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, SortDirection sortDirection);

        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, string nextToken, int maxResults);

        Task<InteractionModelVersionsResponse> Versions(string skillId, string stage, string locale, SortDirection sortDirection, string nextToken, int maxResults);

        Task<SkillModelVersion> Version(string skillId, string stage, string locale, string version);
    }
}
