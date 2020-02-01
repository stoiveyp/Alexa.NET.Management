using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.SkillDevelopment;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillDevelopmentApi:ISkillDevelopmentApi
    {
        private IClientSkillDevelopmentApi Client { get; }

        public SkillDevelopmentApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientSkillDevelopmentApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> CreateSubscriber(CreateSubscriptionRequest request)
        {
            var response = await Client.CreateSubscriber(request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public async Task DeleteSubscriber(string subscriberId)
        {
            var response = await Client.DeleteSubscriber(subscriberId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }
    }
}
