using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Beta;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillBetaApi:IBetaTestApi
    {
        private IClientSkillBetaApi Client {get;}

        public SkillBetaApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientSkillBetaApi>(httpClient);
        }

        public async Task<Uri> Create(string skillId, string feedbackEmail)
        {
            var response = Client.Create(skillId, new BetaTestRequest {FeedbackEmail = feedbackEmail});
        }

        public Task<BetaTest> Get(string skillId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(string skillId, string feedbackEmail)
        {
            var response = await Client.Create(skillId, new BetaTestRequest { FeedbackEmail = feedbackEmail });
        }

        public Task<bool> Start(string skillId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> End(string skillId)
        {
            throw new NotImplementedException();
        }

        public Task<BetaTestersResponse> Testers(string skillId)
        {
            throw new NotImplementedException();
        }

        public Task<BetaTestersResponse> Testers(string skillId, int maxResults)
        {
            throw new NotImplementedException();
        }

        public Task<BetaTestersResponse> Testers(string skillId, int maxResults, string nextToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTesters(string skillId, string[] emails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTesters(string skillId, string[] emails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendReminders(string skillId, string[] emails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestFeedback(string skillId, string[] emails)
        {
            throw new NotImplementedException();
        }
    }
}
