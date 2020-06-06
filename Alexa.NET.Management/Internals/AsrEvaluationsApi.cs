using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Asr.Evaluations;
using Newtonsoft.Json.Linq;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class AsrEvaluationsApi:IAsrEvaluationsApi
    {
        private IClientAsrEvaluationsApi Client { get; }
        public AsrEvaluationsApi(HttpClient client)
        {
            Client = RestService.For<IClientAsrEvaluationsApi>(client);
        }

        public async Task<RunEvaluationsResponse> Run(string skillId, SkillStage stage, string locale, string annotationSetId)
        {
            var response = await Client.Create(skillId, new Asr.Evaluations.RunEvaluationsRequest
            {
                Skill = new SkillInformation{Stage = stage, Locale = locale},
                AnnotationSetId = annotationSetId
            });

            var body = string.Empty;
            if (response.Content != null)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(
                    $"Expected Status Code 200. Received {(int)response.StatusCode}. Response Body: {body}");
            }

            var json = JObject.Parse(body);
            return new RunEvaluationsResponse
            {
                Id = json.Value<string>("id"),
                Location = response.Headers.Location
            };
        }
    }
}
