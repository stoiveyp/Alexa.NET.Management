using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class AccountLinkingApi : IAccountLinkingApi
    {
        private IClientAccountLinkingApi Client { get; }

        public AccountLinkingApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientAccountLinkingApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<AccountLinkData> Get(string skillId, SkillStage stage)
        {
            return (await Client.Get(skillId, stage)).Response;
        }

        public async Task<bool> Delete(string skillId)
        {
            var response = await Client.Delete(skillId, SkillStage.Development);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public Task Update(string skillId, AccountLinkData accountLinkData)
        {
            return Client.Update(skillId, SkillStage.Development, new AccountLinkUpdate { Data = accountLinkData });
        }
    }
}
