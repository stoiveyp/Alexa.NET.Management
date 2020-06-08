using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientAsrEvaluationsApi
    {
        [Post("/v1/skills/{skillId}/asrEvaluations")]
        Task<HttpResponseMessage> Create(string skillId, [Body] Asr.Evaluations.RunEvaluationsRequest request);

        [Delete("/v1/skills/{skillId}/asrEvaluations/{evaluationId}")]
        Task<HttpResponseMessage> Delete(string skillId, string evaluationId);

        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId);
        
        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, Asr.Evaluations.EvaluationResultStatus status);
        
        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, int maxResults);
        
        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, Asr.Evaluations.EvaluationResultStatus status, int maxResults);

        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, string nextToken);
        
        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, Asr.Evaluations.EvaluationResultStatus status, string nextToken);
        
        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/asrEvaluations/{evaluationId}/results")]
        Task<Asr.Evaluations.EvaluationResults> GetResults(string skillId, string evaluationId, Asr.Evaluations.EvaluationResultStatus status, int maxResults, string nextToken);
    }
}