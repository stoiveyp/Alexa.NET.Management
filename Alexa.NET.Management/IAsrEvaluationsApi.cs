using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Asr.Evaluations;

namespace Alexa.NET.Management
{
    public interface IAsrEvaluationsApi
    {
        Task<RunEvaluationsResponse> Run(string skillId, SkillStage stage, string locale, string annotationSetId);
        Task Delete(string skillId, string evaluationId);

        Task<EvaluationResults> GetResults(string skillId, string evaluationId);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, EvaluationResultStatus status);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, int maxResults);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, EvaluationResultStatus status, int maxResults);

        Task<EvaluationResults> GetResults(string skillId, string evaluationId, string nextToken);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, EvaluationResultStatus status, string nextToken);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, int maxResults, string nextToken);
        Task<EvaluationResults> GetResults(string skillId, string evaluationId, EvaluationResultStatus status, int maxResults, string nextToken);
    }
}