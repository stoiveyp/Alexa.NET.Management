using System.Threading.Tasks;
using Alexa.NET.Management.Asr.AnnotationSet;

namespace Alexa.NET.Management
{
    public interface IAsrAnnotationSetsApi
    {
        Task<CreateAnnotationSetResponse> Create(string skillId, string name);

        Task Delete(string skillId, string annotationSetId);

        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId);
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, int maxResults);
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, string nextToken);
        Task<AnnotationSetResponse> GetContent(string skillId, string annotationSetId, int maxResults, string nextToken);

        Task<string> GetContentCsv(string skillId, string annotationSetId);
        Task<AnnotationSetMetadata> GetMetadata(string skillId, string annotationSetId);

        Task<AnnotationSetListResponse> List(string skillId);

        Task<AnnotationSetListResponse> List(string skillId, int maxResults);

        Task<AnnotationSetListResponse> List(string skillId, string nextToken);

        Task<AnnotationSetListResponse> List(string skillId, int maxResults, string nextToken);
    }
}