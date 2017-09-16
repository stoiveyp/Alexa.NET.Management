using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class AccountLinkingApi : IAccountLinkingApi
    {
        private IClientAccountLinkingApi Client { get; }

        public AccountLinkingApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientAccountLinkingApi>(httpClient);
        }

        public async Task<AccountLinkData> Get(string skillId)
        {
            return (await Client.Get(skillId)).Response;
        }

        public Task Update(string skillId, AccountLinkData accountLinkData)
        {
            return Client.Update(skillId, new AccountLinkUpdate { Data = accountLinkData });
        }
    }
}
