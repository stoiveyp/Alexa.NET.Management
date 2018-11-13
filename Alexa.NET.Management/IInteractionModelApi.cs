using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management
{
    public interface IInteractionModelApi
    {
        Task<SkillInteractionResponse> Get(string skillId, string stage, string locale);

        Task<string> GetTag(string skillId, string stage, string locale);

        Task Update(string skillId, string stage, string locale, SkillInteraction interaction);
    }
}
