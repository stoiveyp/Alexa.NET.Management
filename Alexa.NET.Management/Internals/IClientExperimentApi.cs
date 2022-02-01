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

        [Delete("/v1/skills/{skillId}/experiments/{experimentId}")]
        Task<HttpResponseMessage> Delete(string skillId, string experimentId);

        [Post("/v1/skills/{skillId}/experiments/{experimentId}/exposurePercentage")]
        Task<HttpResponseMessage> UpdateExposure(string skillId, string experimentId, [Body]UpdateExposureRequest request);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/treatmentOverrides/~current")]
        Task<GetTreatmentOverrideResponse> GetTreatmentOverride(string skillId, string experimentId);

        [Post("/v1/skills/{skillId}/experiments/{experimentId}/treatmentOverrides/~current")]
        Task<HttpResponseMessage> SetTreatmentOverride(string skillId, string experimentId, SetTreatmentOverrideRequest type);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/state")]
        Task<StateResponse> State(string skillId, string experimentId);

        [Post("/v1/skills/{skillId}/experiments/{experimentId}/state")]
        Task<HttpResponseMessage> State(string skillId, string experimentId, UpdateStateRequest request);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/metricSnapshots")]
        Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/metricSnapshots")]
        Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId, int maxResults);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/metricSnapshots")]
        Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/experiments/{experimentId}/metricSnapshots/{snapshotId}")]
        Task<MetricSnapshotData> MetricSnapshotData(string skillId, string experimentId, string snapshotId);
    }
}
