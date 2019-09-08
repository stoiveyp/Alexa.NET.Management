using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Nlu.Evaluation;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientNluEvaluationApi
    {
        [Post("/skills/{skillId}/nluEvaluations")]
        Task<HttpResponseMessage> Create(string skillId, CreateEvaluationRequest request);

        [Get("/skills/{skillId}/nluEvaluations")]
        Task<ListEvaluationResponse> List(string skillId, string nextToken, string locale, SkillStage? stage, string annotationId, int? maxResults);

        [Get("/skills/{skillId}/nluEvaluations/{evaluationId}")]
        Task<EvaluationStatus> Get(string skillId, string evaluationId);

        [Get("/skills/{skillId}/nluEvaluations/{evaluationId}/results")]
        Task<EvaluationResults> Results(string skillId, string evaluationId, string nextToken, 
            [AliasAs("sort.field")]EvaluationSortField? requestSortField, 
            TestCaseStatus? testCaseStatus,
            string actualIntentName, 
            string expectedIntentName, 
            int? maxResults);
    }
}
