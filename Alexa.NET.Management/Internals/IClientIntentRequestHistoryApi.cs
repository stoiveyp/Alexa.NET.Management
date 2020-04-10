using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.IntentRequestHistory;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientIntentRequestHistoryApi
    {
        [Get("/v1/skills/{skillId}/history/intentRequests")]
        Task<IntentRequestHistoryResponse> Get(string skillId, ClientIntentRequestHistoryRequest request);
    }
}
