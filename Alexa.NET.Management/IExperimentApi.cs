using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Experiments;
using Refit;

namespace Alexa.NET.Management
{
    public interface IExperimentApi
    {
        Task<Uri> Create(string skillId, Experiment request);
        Task<ExperimentResponse<ExperimentDetail>> Get(string skillId, string experimentId);

        Task<ExperimentListResponse> List(string skillId);

        Task<ExperimentListResponse> List(string skillId, int maxResults);

        Task<ExperimentListResponse> List(string skillId, int maxResults, string nextToken);

        Task<ExperimentResponse<Experiment>> Update(string skillId, string experimentId, ExperimentUpdate request);

        Task Delete(string skillId, string experimentId);
        Task UpdateExposure(string skillId, string experimentId, int exposurePercentage);

        Task<GetTreatmentOverrideResponse> GetTreatmentOverride(string skillId, string experimentId);

        Task SetTreatmentOverride(string skillId, string experimentId, TreatmentId type);

        Task<StateResponse> State(string skillId, string experimentId);

        Task State(string skillId, string experimentId, ExperimentUpdateState targetState);
    }
}
