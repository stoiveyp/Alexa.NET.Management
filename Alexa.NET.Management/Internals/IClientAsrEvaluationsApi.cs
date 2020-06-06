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
    }
}