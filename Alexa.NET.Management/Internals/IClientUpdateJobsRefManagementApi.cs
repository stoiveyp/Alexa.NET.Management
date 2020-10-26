using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientUpdateJobsRefManagementApi
    {
        Task<HttpResponseMessage> Create(CreateUpdateJobRequest createUpdateJobRequest);
        Task<IUpdateJobDefinition> Get(string jobId);
        Task<UpdateJobListResponse> List(string vendorId);
        Task<UpdateJobListResponse> List(string vendorId, int maxCount);
        Task<UpdateJobListResponse> List(string vendorId, string nextToken);
        Task<UpdateJobListResponse> List(string vendorId, int maxCount, string nextToken);
        Task<HttpResponseMessage> Delete(string jobId);
    }
}