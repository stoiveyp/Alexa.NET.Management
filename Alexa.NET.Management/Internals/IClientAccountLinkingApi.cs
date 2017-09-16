using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Refit;

namespace Alexa.NET.Management.Internals
{
    [Headers("Authorization")]
    public interface IClientAccountLinkingApi
    {
        [Get("/skills/{skillId}/accountLinkingClient")]
        Task<AccountLinkInformation> Get(string skillId);

        [Put("/skills/{skillId}/accountLinkingClient")]
        Task Update(string skillId, [Body]AccountLinkUpdate information);
    }
}
