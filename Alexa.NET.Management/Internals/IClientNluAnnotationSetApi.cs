using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientNluAnnotationSetApi
    {
        [Post("/v1/skills/{skillId}/nluAnnotationSets")]
        Task<HttpResponseMessage> Create(string skillId, Nlu.AnnotationSet.CreateAnnotationSetRequest request);

        [Get("/v1/skills/{skillId}/nluAnnotationSets")]
        Task<Nlu.AnnotationSet.ListAnnotationSetResponse> List(string skillId, string locale = null, int? maxResults = null, string nextToken = null);

        [Post("/v1/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task Update(string skillId, string annotationId, [Body] Nlu.AnnotationSet.AnnotationSet set);

        [Get("/v1/skills/{skillId}/nluAnnotationSets/{annotationId}/annotations")]
        Task<Nlu.AnnotationSet.AnnotationSet> Get(string skillId, string annotationId,[Header("Accept")]string contentType);

        [Put("/v1/skills/{skillId}/nluAnnotationSets/{annotationId}/properties")]
        Task<HttpResponseMessage> Rename(string skillId, string annotationId, [Body] Nlu.AnnotationSet.UpdatePropertiesRequest request);

        [Get("/v1/skills/{skillId}/nluAnnotationSets/{annotationId}/properties")]
        Task<Nlu.AnnotationSet.AnnotationSetProperties> GetProperties(string skillId, string annotationId);

        [Delete("/v1/skills/{skillId}/nluAnnotationSets/{annotationId}")]
        Task<HttpResponseMessage> Delete(string skillId, string annotationId);
    }
}
