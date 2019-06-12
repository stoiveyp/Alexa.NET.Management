using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.AccountLinking;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Internals;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class AccountLinkingTests
    {
        [Fact]
        public async Task Get()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillId/stages/development/accountLinkingClient", req.RequestUri.PathAndQuery);
            }, new AccountLinkData()));
            var response = await management.AccountLinking.Get("skillId",SkillStage.Development);
        }
    }
}
