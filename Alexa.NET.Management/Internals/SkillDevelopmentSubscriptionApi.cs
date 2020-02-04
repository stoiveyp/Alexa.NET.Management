using System;
using System.Net;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentSubscriptionApi : ISkillDevelopmentSubscriptionApi
    {
        public SkillDevelopmentSubscriptionApi(IClientSkillDevelopmentApi client)
        {
            Client = client;
        }

        private IClientSkillDevelopmentApi Client { get; set; }

        public async Task<Uri> Create(Subscription request)
        {
            var response = await Client.CreateSubscription(request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public async Task Delete(string subscriptionId)
        {
            var response = await Client.DeleteSubscription(subscriptionId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }
    }
}