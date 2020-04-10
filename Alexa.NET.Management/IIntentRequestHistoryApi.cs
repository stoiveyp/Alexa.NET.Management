using System.Threading.Tasks;
using Alexa.NET.Management.IntentRequestHistory;
using Refit;

namespace Alexa.NET.Management
{
    public interface IIntentRequestHistoryApi
    {
        [Get("/v1/skills/{skillId}/history/intentRequests")]
        Task<IntentRequestHistoryResponse> Get(string skillId, IntentRequestHistoryRequest request);
    }
}