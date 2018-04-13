using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Validation;

namespace Alexa.NET.Management
{
    public interface ISkillValidationApi
    {
        Task<SkillValidationResponse> Submit(string skillId, SkillStage stage);
        Task<SkillValidationResponse> Submit(string skillId, SkillStage stage, params string[] locales);
    }
}