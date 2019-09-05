using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.NluEvaluation;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientNluEvaluationApi
    {
        [Post("/skills/{skillId}/nluAnnotationSets")]
        Task<HttpResponseMessage> CreateAnnotationSet(string skillId, CreateAnnotationSetRequest request);

        [Get("/skills/{skillId}/nluAnnotationSets")]
        Task<AnnotationSetsResponse> AnnotationSets(string skillId, string locale = null, int? maxResults = null, string nextToken = null);

        [Post("/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task UpdateAnnotationSet(string skillId, string annotationId, [Body]AnnotationSet set);

        [Get("/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task<AnnotationSet> AnnotationSet(string skillId, string annotationId,[Header("Accept")]string contentType);
    }
}
