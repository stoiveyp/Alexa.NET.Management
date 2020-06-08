using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Asr.AnnotationSet;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientAsrAnnotationSetApi
    {
        [Post("/v1/skills/{skillId}/asrAnnotationSets")]
        Task<HttpResponseMessage> Create(string skillId, [Body] Asr.AnnotationSet.CreateAnnotationSetRequest request);

        [Delete("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}")]
        Task<HttpResponseMessage> Delete(string skillId, string annotationSetId);

        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, int maxResults);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, string nextToken);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, int maxResults, string nextToken);
    }
}
