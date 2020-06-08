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
        Task<HttpResponseMessage> GetContent(string skillId, string annotationSetId, [Header("Accept")] string contentType);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, int maxResults, [Header("Accept")] string contentType);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, string nextToken, [Header("Accept")] string contentType);
        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}/annotations")]
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, int maxResults, string nextToken, [Header("Accept")] string contentType);

        [Get("/v1/skills/{skillId}/asrAnnotationSets/{annotationSetId}")]
        Task<AnnotationSetMetadata> GetMetadata(string skillId, string annotationSetId);
        
    }
}
