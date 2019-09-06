using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Nlu.Evaluation;

namespace Alexa.NET.Management
{
    public interface INluEvaluationApi
    {
        Task<CreateEvaluationResponse> Create(string skillid, SkillStage stage, string locale, string annotationId);

        Task<ListEvaluationResponse> List(string skillId, ListEvaulationFilters filters = null);

        Task<ListEvaluationResponse> List(string skillId, string nextToken, ListEvaulationFilters filters = null);
    }
}
