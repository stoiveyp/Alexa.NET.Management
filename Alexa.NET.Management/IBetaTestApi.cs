using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Beta;
using Alexa.NET.Management.Internals;
using Refit;

namespace Alexa.NET.Management
{
    public interface IBetaTestApi
    {
        Task<Uri> Create(string skillId, string feedbackEmail);

        Task<BetaTest> Get(string skillId);

        Task<bool> Update(string skillId, string feedbackEmail);

        Task<bool> Start(string skillId);

        Task<bool> End(string skillId);

        Task<BetaTestersResponse> Testers(string skillId);

        Task<BetaTestersResponse> Testers(string skillId, int maxResults);

        Task<BetaTestersResponse> Testers(string skillId, int maxResults, string nextToken);

        Task<bool> AddTesters(string skillId, string[] emails);

        Task<bool> RemoveTesters(string skillId, string[] emails);

        Task<bool> SendReminders(string skillId, string[] emails);

        Task<bool> RequestFeedback(string skillId, string[] emails);

    }
}
