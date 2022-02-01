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

        public async Task<Uri> Create(string skillId, Experiment request)
        {
            var response = await Client.Create(skillId, new ExperimentRequest<Experiment>(request));
            return await response.UriOrError(HttpStatusCode.Created);
        }

        public Task<ExperimentResponse<ExperimentDetail>> Get(string skillId, string experimentId)
        {
            return Client.Get(skillId, experimentId);
        }

        public Task<ExperimentListResponse> List(string skillId)
        {
            return Client.List(skillId);
        }

        public Task<ExperimentListResponse> List(string skillId, int maxResults)
        {
            return Client.List(skillId, maxResults);
        }

        public Task<ExperimentListResponse> List(string skillId, int maxResults, string nextToken)
        {
            return Client.List(skillId, maxResults, nextToken);
        }

        public Task<ExperimentResponse<Experiment>> Update(string skillId, string experimentId, ExperimentUpdate request)
        {
            return Client.Update(skillId, experimentId, new ExperimentRequest<ExperimentUpdate>(request));
        }

        public async Task Delete(string skillId, string experimentId)
        {
            var response = await Client.Delete(skillId, experimentId);
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public async Task UpdateExposure(string skillId, string experimentId, int exposurePercentage)
        {
            var response = await Client.UpdateExposure(skillId, experimentId, new UpdateExposureRequest{ExposurePercentage = exposurePercentage});
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public Task<GetTreatmentOverrideResponse> GetTreatmentOverride(string skillId, string experimentId)
        {
            return Client.GetTreatmentOverride(skillId, experimentId);
        }

        public async Task SetTreatmentOverride(string skillId, string experimentId, TreatmentId treatmentId)
        {
            var response = await Client.SetTreatmentOverride(skillId, experimentId,
                new SetTreatmentOverrideRequest { TreatmentId = treatmentId });
            await response.CodeOrError(HttpStatusCode.NoContent);
        }

        public Task<StateResponse> State(string skillId, string experimentId)
        {
            return Client.State(skillId, experimentId);
        }

        public Task State(string skillId, string experimentId, ExperimentUpdateState targetState)
        {
            return Client.State(skillId, experimentId, new UpdateStateRequest { TargetState = targetState });
        }

        public Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId)
        {
            return Client.MetricSnapshots(skillId, experimentId);
        }

        public Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId, int maxResults)
        {
            return Client.MetricSnapshots(skillId, experimentId, maxResults);
        }

        public Task<MetricSnapshotResponse> MetricSnapshots(string skillId, string experimentId, int maxResults, string nextToken)
        {
            return Client.MetricSnapshots(skillId, experimentId, maxResults, nextToken);
        }

        public Task<MetricSnapshotData> MetricSnapshotData(string skillId, string experimentId, string snapshotId)
        {
            return Client.MetricSnapshotData(skillId, experimentId, snapshotId);
        }
    }
}