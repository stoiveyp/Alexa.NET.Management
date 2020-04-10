using System.Threading.Tasks;
using Alexa.NET.Management.Metrics;
using Refit;

namespace Alexa.NET.Management
{
    public interface IMetricsApi
    {
        [Get("/v1/skills/{skillId}/metrics")]
        Task<MetricsResponse> Get(string skillId, MetricsRequest request);

        [Get("/v1/skills/{skillId}/metrics")]
        Task<MetricsResponse> Get(string skillId, int maxResults, MetricsRequest request);

        [Get("/v1/skills/{skillId}/metrics")]
        Task<MetricsResponse> Get(string skillId, int maxResults, string nextToken, MetricsRequest request);
    }
}
