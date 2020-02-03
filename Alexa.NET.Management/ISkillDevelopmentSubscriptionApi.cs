using System;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;

namespace Alexa.NET.Management
{
    public interface ISkillDevelopmentSubscriptionApi
    {
        Task<Uri> Create(Subscription request);
    }
}