using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientExperimentApi
    {
        [Post("/v1/skills/{skillId}/experiments")]
        Task<HttpResponseMessage> Create(string skillId, [Body]ExperimentRequest<Experiment> request);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}")]
        Task<ExperimentResponse<ExperimentDetail>> Get(string skillId, string experimentId);

        [Get("/v1/skills/{skillId}/experiments")]
        Task<ExperimentListResponse> List(string skillId);

        [Get("/v1/skills/{skillId}/experiments")]
        Task<ExperimentListResponse> List(string skillId, int maxResults);

        [Get("/v1/skills/{skillId}/experiments")]
        Task<ExperimentListResponse> List(string skillId, int maxResults, string nextToken);

        [Post("/v1/skills/{skillId}/experiments/{experimentId}/properties")]
        Task<ExperimentResponse<Experiment>> Update(string skillId, string experimentId, [Body] ExperimentRequest<ExperimentUpdate> request);
    }
}
