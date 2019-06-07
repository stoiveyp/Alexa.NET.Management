using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.IntentRequestHistory;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal class IntentRequestHistoryApi:IIntentRequestHistoryApi
    {
        public IntentRequestHistoryApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientIntentRequestHistoryApi>(httpClient);
        }

        public IClientIntentRequestHistoryApi Client { get; set; }

        public Task<IntentRequestHistoryResponse> Get(string skillId, IntentRequestHistoryRequest request)
        {
            return Client.Get(skillId, new ClientIntentRequestHistoryRequest(request));
        }
    }
}
