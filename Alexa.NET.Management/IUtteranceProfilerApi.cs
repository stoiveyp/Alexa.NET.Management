using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.UtteranceProfiler;

namespace Alexa.NET.Management
{
    public interface IUtteranceProfilerApi
    {
        Task<UtteranceProfilerResponse> Analyze(string skillId, SkillStage stage, string locale,string utterance, string multiTurnToken = null);
    }
}
