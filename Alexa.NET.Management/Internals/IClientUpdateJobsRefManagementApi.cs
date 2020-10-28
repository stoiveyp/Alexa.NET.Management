using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientUpdateJobsRefManagementApi
    {
        [Post("/v1/skills/api/custom/interactionModel/jobs")]
        Task<HttpResponseMessage> Create([Body]CreateUpdateJobRequest createUpdateJobRequest);

        [Post("/v1/skills/api/custom/interactionModel/jobs/{jobId}")]
        Task<IUpdateJobDefinition> Get(string jobId);

        [Post("/v1/skills/api/custom/interactionModel/jobs")]
        Task<UpdateJobListResponse> List(string vendorId);

        [Get("/v1/skills/api/custom/interactionModel/jobs")]
        Task<UpdateJobListResponse> List(string vendorId, int maxCount);

        [Get("/v1/skills/api/custom/interactionModel/jobs")]
        Task<UpdateJobListResponse> List(string vendorId, string nextToken);

        [Get("/v1/skills/api/custom/interactionModel/jobs")]
        Task<UpdateJobListResponse> List(string vendorId, int maxCount, string nextToken);

        [Delete("/v1/skills/api/custom/interactionModel/jobs/{jobId}")]
        Task<HttpResponseMessage> Delete(string jobId);

        [Post("/v1/skills/api/custom/interactionModel/jobs/{jobId}/status")]
        Task<HttpResponseMessage> ChangeStatus(string jobId, [Body]ChangeStatusRequest request);

        [Get("/v1/skills/api/custom/interactionModel/jobs/{jobId}/execution")]
        Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId);

        [Get("/v1/skills/api/custom/interactionModel/jobs/{jobId}/execution")]
        Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId, SortDirection sortDirection);

        [Get("/v1/skills/api/custom/interactionModel/jobs/{jobId}/execution")]
        Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId, string nextToken, int maxCount);

        [Get("/v1/skills/api/custom/interactionModel/jobs/{jobId}/execution")]
        Task<UpdateJobExecutionHistoryResponse> ListExecutionHistory(string jobId, SortDirection sortDirection, string nextToken, int maxCount);

        [Delete("/v1/skills/api/custom/interactionModel/jobs/{jobId}/executions/{executionId}")]
        Task CancelNextExecution(string jobId, string executionId);
    }
}