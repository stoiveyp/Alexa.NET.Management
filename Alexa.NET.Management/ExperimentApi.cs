using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Alexa.NET.Management.Internals;
using Refit;

namespace Alexa.NET.Management
{
    public class ExperimentApi:IExperimentApi
    {
        private IClientExperimentApi Client { get; }

        public ExperimentApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientExperimentApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task<Uri> Create(string skillId, CreateExperimentRequest request)
        {
            var response = await Client.Create(skillId, request);
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public Task<ExperimentDetailResponse> Get(string skillId, string experimentId)
        {
            return Client.Get(skillId, experimentId);
        }
    }
}