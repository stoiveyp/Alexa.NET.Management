using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.IntentRequestHistory;
using Newtonsoft.Json;
using Refit;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class IntentRequestHistoryTests
    {
        [Fact]
        public async Task RequestHistoryGeneratesSimpleRequest()
        {
            string uri = null;
            try
            {
                var api = new ManagementApi("wibble");

                var request = new IntentRequestHistoryRequest
                {
                    NextToken = "yyy"
                };


                var response = await api.IntentRequestHistory.Get("xxx", request);
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

                var request = new IntentRequestHistoryRequest
                {
                    NextToken = "yyy",
                    Stage = SkillStage.DEVELOPMENT,
                    InteractionType = InteractionType.ONE_SHOT
                };


                var response = await api.IntentRequestHistory.Get("xxx", request);
                Assert.NotNull(response);
            }
            catch (ApiException ex)
            {
                uri = ex.Uri.PathAndQuery;
            }

            Assert.Equal("/v1/skills/xxx/history/intentRequests?nextToken=yyy&stage=DEVELOPMENT&interactionType=ONE_SHOT", uri);
        }

        [Fact]
        public void ResponseDeserializesProperly()
        {
            var response = GetFromFile<IntentRequestHistoryResponse>("Examples/IntentRequestHistoryResponse.json");         
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

		private JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings());

        private T GetFromFile<T>(string path)
        {
            using (var reader = new JsonTextReader(File.OpenText(path)))
            {
                return Serializer.Deserialize<T>(reader);
            }
        }
    }
}
