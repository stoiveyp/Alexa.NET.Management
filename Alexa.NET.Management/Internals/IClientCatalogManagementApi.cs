using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.CatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientCatalogManagementApi
    {
        [Post("/v0/catalogs")]
        Task<HttpResponseMessage> Create([Body]CatalogCreationRequest request);

        [Put("/v0/skills/{skillId}/catalogs/{catalogId}")]
        Task<HttpResponseMessage> Associate(string skillId, string catalogId);

        [Get("/v0/catalogs")]
        Task<CatalogListResponse> List(string vendorId);

        [Get("/v0/catalogs")]
        Task<CatalogListResponse> List(string vendorId, int maxResults);

        [Get("/v0/catalogs")]
        Task<CatalogListResponse> List(string vendorId, int maxResults, string nextToken);

        [Get("/v0/catalogs/{catalogId}")]
        Task<Catalog> Get(string catalogId);

        [Post("/v0/catalogs/{catalogId}/uploads")]
        Task<Upload> CreateUpload(string catalogId, [Body]CreateUploadRequest request);

        [Post("/v0/catalogs/{catalogId}/uploads/{uploadId}")]
        Task<HttpResponseMessage> CompleteUpload(string catalogId, string uploadId, [Body]UploadCompleteRequest request);

        [Get("/v0/catalogs/{catalogId}/uploads/{uploadId}")]
        Task<Upload> GetUpload(string catalogId, string uploadId);

        [Get("/v0/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId);

        [Get("/v0/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId, int maxResults);

        [Get("/v0/catalogs/{catalogId}/uploads")]
        Task<UploadListResponse> ListUploads(string catalogId, int maxResults, string nextToken);
    }
}
