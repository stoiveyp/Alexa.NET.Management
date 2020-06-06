using System.Threading.Tasks;
using Alexa.NET.Management.Asr.AnnotationSet;

namespace Alexa.NET.Management
{
    public interface IAsrAnnotationSetsApi
    {
        Task<CreateAnnotationSetResponse> Create(string skillId, string name);
    }
}