using System.Threading.Tasks;
using Alexa.NET.Management.Asr.AnnotationSet;

namespace Alexa.NET.Management
{
    public interface IAsrAnnotationSetsApi
    {
        Task<CreateAnnotationSetResponse> Create(string skillId, string name);

        Task Delete(string skillId, string annotationSetId);

        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId);
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, int maxResults);
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, string nextToken);
        Task<AnnotationSetResponse> Get(string skillId, string annotationSetId, int maxResults, string nextToken);

        Task<string> GetCsv(string skillId, string annotationSetId);
    }
}