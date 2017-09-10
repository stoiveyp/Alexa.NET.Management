using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization: Bearer")]
    public interface IAccountLinkingApi
    {
        [Get("skills/{skilIid}/accountLinkingClient")]
        Task<AccountLinkInformation> Get(string skillId);

        [Put("skills/{skillId}/accountLinkingClient")]
        Task Update(string skillId, [Body]AccountLinkUpdate information);
    }
}
