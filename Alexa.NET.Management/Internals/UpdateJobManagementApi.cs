using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal class UpdateJobManagementApi:IUpdateJobsManagementApi
    {
        internal IClientUpdateJobsRefManagementApi Client{ get; }

        public UpdateJobManagementApi(HttpClient client)
        {
            Client = RestService.For<IClientUpdateJobsRefManagementApi>(client, ManagementRefitSettings.Create());
        }

        public async Task<Uri> Create(string vendorId, IUpdateJobDefinition job)
        {
            var response = await Client.Create(new CreateUpdateJobRequest {VendorId = vendorId, JobDefinition = job});
            return await response.UriOrError(HttpStatusCode.OK);
        }

        public Task<IUpdateJobDefinition> Get(string jobId)
        {
            return Client.Get(jobId);
        }

        public Task<UpdateJobListResponse> List(string vendorId)
        {
            return Client.List(vendorId);
        }

        public Task<UpdateJobListResponse> List(string vendorId, int maxCount)
        {
            return Client.List(vendorId, maxCount);
        }

        public Task<UpdateJobListResponse> List(string vendorId, string nextToken)
        {
            return Client.List(vendorId, nextToken);
        }

        public Task<UpdateJobListResponse> List(string vendorId, int maxCount, string nextToken)
        {
            return Client.List(vendorId, maxCount, nextToken);
        }

        public Task Delete(string jobId)
        {
            return Client.Delete(jobId);
        }

        public Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId)
        {
            return Client.ListExecutionHistory(jobId);
        }

        public Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId, SortDirection sortDirection)
        {
            return Client.ListExecutionHistory(jobId, sortDirection);
        }

        public Task<UpdateJobExecutionHistoryResponse> ListVersions(string jobId, string nextToken, int maxResults)
        {
            return Client.ListExecutionHistory(jobId, nextToken, maxResults);
        }

        public Task<UpdateJobExecutionHistoryResponse> ListVersions(string jobId, SortDirection sortDirection, string nextToken, int maxResults)
        {
            return Client.ListExecutionHistory(jobId, sortDirection, nextToken, maxResults);
        }

        public Task CancelNextExecution(string jobId, string executionId)
        {
            return Client.CancelNextExecution(jobId, executionId);
        }

        public Task EnableJob(string jobId)
        {
            return Client.ChangeStatus(jobId, new ChangeStateRequest {Status = "ENABLED"});
        }

        public Task DisableJob(string jobId)
        {
            return Client.ChangeStatus(jobId, new ChangeStateRequest { Status = "DISABLED" });
        }
    }
}
