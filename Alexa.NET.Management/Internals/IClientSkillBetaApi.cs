using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Beta;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillBetaApi
    {
        [Post("/skills/{skillId}/betaTest")]
        Task<HttpResponseMessage> Create(string skillId, BetaTestRequest request);

        [Get("/skills/{skillId}/betaTest")]
        Task<BetaTest> Get(string skillId);

        [Put("/skills/{skillId}/betaTest")]
        Task<HttpResponseMessage> Update(string skillId, BetaTestRequest request);

        [Post("/skills/{skillId}/betaTest/start")]
        Task<HttpResponseMessage> Start(string skillId);

        [Post("/skills/{skillId}/betaTest/end")]
        Task<HttpResponseMessage> End(string skillId);

        [Get("/skills/{skillId}/betaTest/testers")]
        Task<BetaTestersResponse> Testers(string skillId);

        [Get("/skills/{skillId}/betaTest/testers")]
        Task<BetaTestersResponse> Testers(string skillId, int maxResults);

        [Get("/skills/{skillId}/betaTest/testers")]
        Task<BetaTestersResponse> Testers(string skillId, int maxResults, string nextToken);

        [Post("/skills/{skillId}/betaTest/testers/add")]
        Task<HttpResponseMessage> AddTesters(string skillId, TesterRequest request);

        [Post("/skills/{skillId}/betaTest/testers/remove")]
        Task<HttpResponseMessage> RemoveTesters(string skillId, TesterRequest request);

        [Post("/skills/{skillId}/betaTest/testers/sendReminder")]
        Task<HttpResponseMessage> SendReminders(string skillId, TesterRequest request);

        [Post("/skills/{skillId}/betaTest/testers/requestFeedback")]
        Task<HttpResponseMessage> RequestFeedback(string skillId, TesterRequest request);

    }
}
