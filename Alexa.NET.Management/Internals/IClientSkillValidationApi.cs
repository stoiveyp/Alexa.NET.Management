using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Validation;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillValidationApi
    {
        [Post("/skills/{skillId}/stage/{stage}/validations")]
        Task<SkillValidationResponse> Submit(string skillId, SkillStage stage);

        [Post("/skills/{skillId}/stage/{stage}/validations")]
        Task<SkillValidationResponse> Submit(string skillId, SkillStage stage, [Body]SkillValidationRequest request);

        [Get("/skills/{skillId}/stages/{stage}/validations/{validationId}")]
        Task<SkillValidationResponse> Get(string skillId, SkillStage stage, string validationId);
    }
}
