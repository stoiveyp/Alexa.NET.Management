using System.Net.Http;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentApi:ISkillDevelopmentApi
    {
        private IClientSkillDevelopmentApi Client { get; }
        public ISkillDevelopmentSubscriberApi Subscriber { get; }

        public ISkillDevelopmentSubscriptionApi Subscription { get; }

        public SkillDevelopmentApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientSkillDevelopmentApi>(httpClient, ManagementRefitSettings.Create());
            Subscriber = new SkillDevelopmentSubscriberApi(Client);
            Subscription = new SkillDevelopmentSubscriptionApi(Client);
        }
    }
}
