using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            Client = RestService.For<IClientSkillBetaApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> Create(string skillId, string feedbackEmail)
        {
            var response = await Client.Create(skillId, new BetaTestRequest {FeedbackEmail = feedbackEmail});
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public Task<BetaTest> Get(string skillId)
        {
            return Client.Get(skillId);
        } 

        public async Task<bool> Update(string skillId, string feedbackEmail)
        {
            var response = await Client.Update(skillId, new BetaTestRequest { FeedbackEmail = feedbackEmail });
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Start(string skillId)
        {
            var response = await Client.Start(skillId);
            return response.StatusCode == HttpStatusCode.Accepted;
        }

        public async Task<bool> End(string skillId)
        {
            var response = await Client.End(skillId);
            return response.StatusCode == HttpStatusCode.Accepted;
        }

        public Task<BetaTestersResponse> Testers(string skillId)
        {
            return Client.Testers(skillId);
        }

        public Task<BetaTestersResponse> Testers(string skillId, int maxResults)
        {
            return Client.Testers(skillId, maxResults);
        }

        public Task<BetaTestersResponse> Testers(string skillId, int maxResults, string nextToken)
        {
            return Client.Testers(skillId, maxResults, nextToken);
        }

        public async Task<bool> AddTesters(string skillId, IEnumerable<string> emails)
        {
            var response = await Client.AddTesters(skillId, ToRequest(emails));
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> RemoveTesters(string skillId, IEnumerable<string> emails)
        {
            var response = await Client.RemoveTesters(skillId, ToRequest(emails));
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> SendReminders(string skillId, IEnumerable<string> emails)
        {
            var response = await Client.SendReminders(skillId, ToRequest(emails));
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> RequestFeedback(string skillId, IEnumerable<string> emails)
        {
            var response = await Client.RequestFeedback(skillId, ToRequest(emails));
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        private TesterRequest ToRequest(IEnumerable<string> emails)
        {
            return new TesterRequest {Testers = emails.Select(e => new TesterEmail {Email = e}).ToArray()};
        }
    }
}
