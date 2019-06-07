using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Alexa.NET.Management.Api;
using Refit;

namespace Alexa.NET.Management
{
    public interface IAccountLinkingApi
    {
        Task<AccountLinkData> Get(string skillId, SkillStage stage);
        Task<bool> Delete(string skillId);
        Task Update(string skillId, AccountLinkData accountLinkData);
    }
}
