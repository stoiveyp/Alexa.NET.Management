using System.Threading.Tasks;
using Alexa.NET.Management.Internals;

namespace Alexa.NET.Management
{
    public interface IInteractionModelApi
    {
        Task<SkillInteraction> Get(string skillId, string locale);

        Task<string> GetTag(string skillId, string locale);

        Task Update(string skillId, string locale, SkillInteraction interaction);

        Task<BuildStatus> Status(string skillId, string locale);
    }
}
