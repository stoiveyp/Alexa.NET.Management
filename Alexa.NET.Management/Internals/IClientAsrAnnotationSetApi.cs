using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientAsrAnnotationSetApi
    {
        [Post("/v1/skills/{skillId}/asrAnnotationSets")]
        Task<HttpResponseMessage> Create(string skillId, [Body] Asr.AnnotationSet.CreateAnnotationSetRequest request);
    }
}
