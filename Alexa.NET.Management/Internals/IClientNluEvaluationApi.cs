using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientNluEvaluationApi
    {
        [Post("/v1/skills/{skillId}/nluEvaluations")]
        Task<HttpResponseMessage> Create(string skillId, Nlu.Evaluation.CreateEvaluationRequest request);

        [Get("/v1/skills/{skillId}/nluEvaluations")]
        Task<Nlu.Evaluation.ListEvaluationResponse> List(string skillId, string nextToken, string locale, SkillStage? stage, string annotationId, int? maxResults);

        [Get("/v1/skills/{skillId}/nluEvaluations/{evaluationId}")]
        Task<Nlu.Evaluation.EvaluationStatusWithLinks> Get(string skillId, string evaluationId);

        [Get("/v1/skills/{skillId}/nluEvaluations/{evaluationId}/results")]
        Task<Nlu.Evaluation.EvaluationResults> Results(string skillId, string evaluationId, string nextToken, 
            [AliasAs("sort.field")] Nlu.Evaluation.EvaluationSortField? requestSortField,
            Nlu.Evaluation.TestCaseStatus? testCaseStatus,
            string actualIntentName, 
            string expectedIntentName, 
            int? maxResults);
    }
}
