using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class AccountLinkingApi : IAccountLinkingApi
    {
        private IClientAccountLinkingApi Client { get; }

        public AccountLinkingApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            Client = RestService.For<IClientAccountLinkingApi>(
                baseAddress.ToString(),
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = getToken
                });
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
