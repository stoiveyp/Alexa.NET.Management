using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.NluEvaluation;
using Newtonsoft.Json.Linq;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class NluEvaluationApi:INluEvaluationApi
    {
        private IClientNluEvaluationApi Client { get; }

        public NluEvaluationApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientNluEvaluationApi>(httpClient, ManagementRefitSettings.Create());
        }

        public Task<CreateAnnotationSetResponse> CreateAnnotationSet(string skillId, string locale, string name)
        {
            return CreateAnnotationSet(skillId, new CreateAnnotationSetRequest
            {
                Locale = locale,
                Name = name
            });
        }

        public async Task<CreateAnnotationSetResponse> CreateAnnotationSet(string skillId, CreateAnnotationSetRequest request)
        {
            var response = await Client.CreateAnnotationSet(skillId, request);

            var body = string.Empty;
            if (response.Content != null)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new InvalidOperationException(
                    $"Expected Status Code 201. Received {(int)response.StatusCode}. Response Body: {body}");
            }

            var json = JObject.Parse(body);
            return new CreateAnnotationSetResponse
            {
                Id = json.Value<string>("id"),
                Location = response.Headers.Location
            };
        }
    }
}
