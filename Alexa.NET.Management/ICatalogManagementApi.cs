using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.CatalogManagement;

namespace Alexa.NET.Management
{
    public interface ICatalogManagementApi
    {
        Task Create(CatalogCreationRequest request);

        Task Associate(string skillId, string catalogId);

        Task<CatalogListResponse> List(string vendorId);

        Task<CatalogListResponse> List(string vendorId, int maxResults);

        Task<CatalogListResponse> List(string vendorId, int maxResults, string nextToken);

        Task<Catalog> Get(string catalogId);

        Task<Upload> CreateUpload(string catalogId, int numberOfParts = 1);

        Task<UploadCompleteResponse> CompleteUpload(string catalogId, string uploadId);

        Task<Upload> GetUpload(string catalogId, string uploadId);

        Task<UploadListResponse> ListUploads(string catalogId);

        Task<UploadListResponse> ListUploads(string catalogId, int maxResults);

        Task<UploadListResponse> ListUploads(string catalogId, int maxResults, string nextToken);
    }
}
