using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Refit;

namespace Alexa.NET.Management
{
    public interface IAccountLinkingApi
    {
        Task<AccountLinkData> Get(string skillId, string stage);
        Task<bool> Delete(string skillId);
        Task Update(string skillId, AccountLinkData accountLinkData);
    }
}
