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
    }
}
