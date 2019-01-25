using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.UtteranceProfiler;
using Refit;

namespace Alexa.NET.Management.Internals
{
    interface IClientUtteranceProfilerApi
    {
        [Post("/skills/{skillId}/stages/{stage}/interactionModel/locales/{locale}/profileNlu")]
        Task<UtteranceProfilerResponse> Analyze(string skillId, SkillStage stage, string locale, UtteranceProfilerRequest request);
    }
}
