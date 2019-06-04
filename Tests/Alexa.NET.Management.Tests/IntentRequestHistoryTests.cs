using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.IntentRequestHistory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class IntentRequestHistoryTests
    {
        [Fact]
        public async Task RequestHistoryGeneratesSimpleRequest()
        {
            var api = new ManagementApi("wibble", new ActionHandler(req =>
             {
                 Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy", req.RequestUri.PathAndQuery);
             }, new IntentRequestHistoryResponse()));

            var request = new IntentRequestHistoryRequest
            {
                NextToken = "yyy"
            };


            var response = await api.IntentRequestHistory.Get("xxx", request);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RequestHistoryGeneratesLargerRequest()
        {
            var api = new ManagementApi("wibble", new ActionHandler(req =>
            {
                Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy&stage=development&interactionType=ONE_SHOT", req.RequestUri.PathAndQuery);
            }, new IntentRequestHistoryResponse()));

            var request = new IntentRequestHistoryRequest
            {
                NextToken = "yyy",
                Stage = SkillStage.development,
                InteractionType = InteractionType.ONE_SHOT
            };


            var response = await api.IntentRequestHistory.Get("xxx", request);
            Assert.NotNull(response);
        }

        [Fact]
        public void ResponseDeserializesProperly()
        {
            var response = Utility.ExampleFileContent<IntentRequestHistoryResponse>("IntentRequestHistoryResponse.json");
            var body = response.Body;

            Assert.NotNull(body);
            Assert.Equal(2, body.Links.Count);
            Assert.Equal(
                "v1/skills/{skillId}/history/intentRequests?nextToken=VXjbbbbbbbbb&maxResults=5&sortDirection=desc&sortField=intent.confidence.bin&locale=en-US&locale=en-GB&locale=de-DE&intent.confidence.bin=HIGH&intent.confidence.bin=MEDIUM&stage=development&publicationStatus=CERTIFICATION&dialogAct.name=Dialog.ElicitSlot&dialogAct.name=Dialog.ConfirmSlot&intent.slots.name=answer&utteranceText=answer&intent.name=AnswerIntent&interactionType=MODAL",
                body.Links["next"].Href
                );
            Assert.Equal(5, body.Items.Length);
            var testItem = body.Items[2];

            Assert.Equal(InteractionType.MODAL, testItem.InteractionType);
            Assert.Equal("the answer is apollo", testItem.UtteranceText);
        }

        private readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings());
    }
}
