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
        Task<HttpResponseMessage> Create(string skillId, CreateExperimentRequest request);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}")]
        Task<ExperimentDetailResponse> Get(string skillId, string experimentId);
    }
}
