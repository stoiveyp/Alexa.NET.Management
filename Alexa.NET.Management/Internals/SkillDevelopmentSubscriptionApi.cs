using System;
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

        public Task<Uri> Create(Subscription request)
        {
            throw new NotImplementedException();
        }
    }
}