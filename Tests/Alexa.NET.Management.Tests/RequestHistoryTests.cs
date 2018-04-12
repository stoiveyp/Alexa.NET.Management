using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.IntentHistory;
using Refit;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class RequestHistoryTests
    {
        [Fact]
        public async Task RequestHistoryGeneratesSimpleRequest()
        {
            string uri = null;
            try
            {
                var api = new ManagementApi("wibble");

                var request = new IntentHistoryRequest
                {
                    NextToken = "yyy"
                };


                var response = await api.RequestHistory.Get("xxx", request);
                Assert.NotNull(response);
            }
            catch (ApiException ex)
            {
                uri = ex.Uri.PathAndQuery;
            }

            Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy",uri);
        }

        [Fact]
        public async Task RequestHistoryGeneratesLargerRequest()
        {
            string uri = null;
            try
            {
                var api = new ManagementApi("wibble");

                var request = new IntentHistoryRequest
                {
                    NextToken = "yyy",
                    Stage = SkillStage.DEVELOPMENT
                };


                var response = await api.RequestHistory.Get("xxx", request);
                Assert.NotNull(response);
            }
            catch (ApiException ex)
            {
                uri = ex.Uri.PathAndQuery;
            }

            Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy&stage=DEVELOPMENT", uri);
        }
    }
}
