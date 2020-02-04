using System.Net.Http;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentApi
    {
        ISkillDevelopmentSubscriberApi Subscriber { get; }
        ISkillDevelopmentSubscriptionApi Subscription { get; }
    }
}
