using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.IntentHistory;
using Refit;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class RequestHistoryTests
    {
        [Fact]
        public async Task RequestHistoryGeneratesGetRequest()
        {
            string uri = null;
            try
            {
                var api = new ManagementApi("wibble");
                var response = await api.RequestHistory.Get("xxx", new IntentHistoryRequest {NextToken = "yyy"});
                Assert.NotNull(response);
            }
            catch (ApiException ex)
            {
                uri = ex.Uri.PathAndQuery;
            }

            Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy",uri);
        }
    }
}
