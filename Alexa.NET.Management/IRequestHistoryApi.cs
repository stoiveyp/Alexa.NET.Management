using System.Threading.Tasks;
using Alexa.NET.Management.IntentHistory;
using Refit;

namespace Alexa.NET.Management
{
    public interface IRequestHistoryApi
    {
        [Get("/skills/{skillId}/history/intentRequests")]
        Task<IntentHistoryResponse> Get(string skillId, IntentHistoryRequest request);
    }
}