using System.Threading.Tasks;
using Alexa.NET.Management.Nlu.AnnotationSet;

namespace Alexa.NET.Management
{
    public interface INluAnnotationSetApi
    {
        Task<CreateAnnotationSetResponse> Create(string skillId, string locale, string name);

        Task<ListAnnotationSetResponse> List(string skillId, string locale = null, int? maxResults = null);

        Task<ListAnnotationSetResponse> List(string skillId, string nextToken, string locale = null, int? maxResults = null);

        Task<AnnotationSet> Get(string skillId, string annotationId);

        Task Update(string skillId, string annotationId, AnnotationSet set);

        Task Rename(string skillId, string annotationId, string name);

        Task<AnnotationSetProperties> GetProperties(string skillId, string annotationId);
        Task Delete(string skillId, string annotationId);
    }
}
