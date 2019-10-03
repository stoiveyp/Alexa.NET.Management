using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.CatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientCatalogManagementApi
    {
        [Post("/catalogs")]
        Task<HttpResponseMessage> Create([Body]CatalogCreationRequest request);

        [Put("/skills/{skillId}/catalogs/{catalogId}")]
        Task<HttpResponseMessage> Associate(string skillId, string catalogId);

        [Get("/catalogs")]
        Task<CatalogListResponse> List(string vendorId);

        [Get("/catalogs")]
        Task<CatalogListResponse> List(string vendorId, int maxResults);

        [Get("/catalogs")]
        Task<CatalogListResponse> List(string vendorId, int maxResults, string nextToken);

        [Get("/catalogs/{catalogId}")]
        Task<Catalog> Get(string catalogId);

        [Post("/catalogs/{catalogId}/uploads")]
        Task<Upload> CreateUpload(string catalogId, [Body]CreateUploadRequest request);

        [Post("/catalogs/{catalogId}/uploads/{uploadId}")]
        Task<HttpResponseMessage> CompleteUpload(string catalogId, string uploadId, [Body]UploadCompleteRequest request);

        [Get("/catalogs/{catalogId}/uploads/{uploadId}")]
        Task<Upload> GetUpload(string catalogId, string uploadId);

        [Get("/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId);

        [Get("/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId, int maxResults);

        [Get("/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId, int maxResults, string nextToken);
    }
}
