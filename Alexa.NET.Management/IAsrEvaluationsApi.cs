using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Asr.Evaluations;

namespace Alexa.NET.Management
{
    public interface IAsrEvaluationsApi
    {
        Task<RunEvaluationsResponse> Run(string skillId, SkillStage stage, string locale, string annotationSetId);
    }
}