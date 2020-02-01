using System;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentApi
    {
        Task<Uri> CreateSubscription(CreateSubscriptionRequest request);
    }
}
