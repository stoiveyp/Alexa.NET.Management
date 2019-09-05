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
    public class NluEvaluationApi : INluEvaluationApi
    {
        private IClientNluEvaluationApi Client { get; }

        public NluEvaluationApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientNluEvaluationApi>(httpClient, ManagementRefitSettings.Create());
        }

        public Task<CreateAnnotationSetResponse> Create(string skillId, string locale, string name)
        {
            return Create(skillId, new CreateRequest
            {
                Locale = locale,
                Name = name
            });
        }

        public Task<ListResponse> List(string skillId, string locale = null, int? maxResults = null)
        {
            return List(skillId, null, locale, maxResults);
        }

        public Task<ListResponse> List(string skillId, string nextToken, string locale = null, int? maxResults = null)
        {
            return Client.List(skillId, locale, maxResults, nextToken);
        }

        public Task<AnnotationSet> Get(string skillId, string annotationId)
        {
            return Client.Get(skillId, annotationId, "application/json");
        }

        public Task Update(string skillId, string annotationId, AnnotationSet set)
        {
            return Client.Update(skillId, annotationId, set);
        }

        public async Task Rename(string skillId, string annotationId, string name)
        {
            var response = await Client.Rename(skillId, annotationId, new UpdatePropertiesRequest { Name = name });

            if (response.StatusCode != HttpStatusCode.Created)
            {

                var body = string.Empty;
                if (response.Content != null)
                {
                    body = await response.Content.ReadAsStringAsync();
                }

                throw new InvalidOperationException(
                    $"Expected Status Code 201. Received {(int)response.StatusCode}. Response Body: {body}");
            }
        }

        public async Task<AnnotationSetProperties> GetProperties(string skillId, string annotationId)
        {
            var result = await Client.GetProperties(skillId, annotationId);
            result.AnnotationId = annotationId;
            return result;
        }

        private async Task<CreateAnnotationSetResponse> Create(string skillId, CreateRequest request)
        {
            var response = await Client.Create(skillId, request);

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
