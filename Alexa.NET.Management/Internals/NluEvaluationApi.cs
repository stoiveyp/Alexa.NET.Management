using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Nlu;
using Alexa.NET.Management.Nlu.Evaluation;
using Newtonsoft.Json.Linq;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class NluEvaluationApi : INluEvaluationApi
    {
        private IClientNluEvaluationApi Client { get; }

        public NluEvaluationApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientNluEvaluationApi>(httpClient, ManagementRefitSettings.Create());
        }

        public Task<CreateEvaluationResponse> Create(string skillId, SkillStage stage, string locale, string annotationId)
        {
            return Create(skillId, new CreateEvaluationRequest(stage, locale, annotationId));
        }

        public Task<ListEvaluationResponse> List(string skillId, ListEvaulationFilters filters = default(ListEvaulationFilters))
        {
            return List(skillId, string.Empty, filters);
        }

        public Task<ListEvaluationResponse> List(string skillId, string nextToken, ListEvaulationFilters filters = default(ListEvaulationFilters))
        {
            return Client.List(skillId, nextToken, filters?.Locale, filters?.Stage, filters?.AnnotationId,
                filters?.MaxResults);
        }

        private async Task<CreateEvaluationResponse> Create(string skillId, CreateEvaluationRequest request)
        {
            var response = await Client.Create(skillId, request);

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
            return new CreateEvaluationResponse
            {
                Id = json.Value<string>("id"),
                Location = response.Headers.Location
            };
        }
    }
}
