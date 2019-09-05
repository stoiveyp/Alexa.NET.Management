using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.NluEvaluation;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientNluEvaluationApi
    {
        [Post("/skills/{skillId}/nluAnnotationSets")]
        Task<HttpResponseMessage> Create(string skillId, CreateRequest request);

        [Get("/skills/{skillId}/nluAnnotationSets")]
        Task<ListResponse> List(string skillId, string locale = null, int? maxResults = null, string nextToken = null);

        [Post("/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task Update(string skillId, string annotationId, [Body]AnnotationSet set);

        [Get("/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task<AnnotationSet> Get(string skillId, string annotationId,[Header("Accept")]string contentType);

        [Put("/skills/{skillId}/nluAnnotationSets/{annotationId}/properties")]
        Task<HttpResponseMessage> Rename(string skillId, string annotationId, [Body]UpdatePropertiesRequest request);

        [Get("/skills/{skillId}/nluAnnotationSets/{annotationId}/properties")]
        Task<AnnotationSetProperties> GetProperties(string skillId, string annotationId);

        [Delete("/skills/{skillId}/nluAnnotationSets/{annotationId}")]
        Task<HttpResponseMessage> Delete(string skillId, string annotationId);
    }
}
