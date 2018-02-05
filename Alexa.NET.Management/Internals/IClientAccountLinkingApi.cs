using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientAccountLinkingApi
    {
        [Get("/skills/{skillId}/stages/{stage}/accountLinkingClient")]
        Task<AccountLinkInformation> Get(string skillId, string stage);

        [Put("/skills/{skillId}/stages/{stage}/accountLinkingClient")]
        Task Update(string skillId, string stage, [Body]AccountLinkUpdate information);

        [Delete("/skills/{skillId}/stages/{stage}/accountLinkingClient")]
        Task<HttpResponseMessage> Delete(string skillId, string stage);
    }
}
