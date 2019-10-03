using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.CatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillCatalogManagementApi : ICatalogManagementApi
    {
        private IClientCatalogManagementApi Client { get; }

        public SkillCatalogManagementApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientCatalogManagementApi>(httpClient, ManagementRefitSettings.Create());
        }

        public async Task Create(CatalogCreationRequest request)
        {
            var response = await Client.Create(request);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException(
                    $"Expected Status Code 201. Received {(int)response.StatusCode}. Response Body: {body}");
            }

        }

        public async Task Associate(string skillId, string catalogId)
        {
            var response = await Client.Associate(skillId, catalogId);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException(
                    $"Expected Status Code 201. Received {(int)response.StatusCode}. Response Body: {body}");
            }
        }

        public Task<CatalogListResponse> List(string vendorId)
        {
            return Client.List(vendorId);
        }

        public Task<CatalogListResponse> List(string vendorId, int maxResults)
        {
            return Client.List(vendorId,maxResults);
        }

        public Task<CatalogListResponse> List(string vendorId, int maxResults, string nextToken)
        {
            return Client.List(vendorId,maxResults,nextToken);
        }

        public Task<Catalog> Get(string catalogId)
        {
            return Client.Get(catalogId);
        }

        public Task<Upload> CreateUpload(string catalogId, int numberOfParts = 1)
        {
            return Client.CreateUpload(catalogId, new CreateUploadRequest {NumberOfUploadParts = numberOfParts});
        }

        public async Task CompleteUpload(string catalogId, string uploadId, UploadCompleteRequest request)
        {
            var response = await Client.CompleteUpload(catalogId, uploadId, request);
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException(
                    $"Expected Status Code 202. Received {(int)response.StatusCode}. Response Body: {body}");
            }
        }

        public Task<Upload> GetUpload(string catalogId, string uploadId)
        {
            return Client.GetUpload(catalogId, uploadId);
        }

        public Task<UploadListResponse> ListUploads(string catalogId)
        {
            return Client.ListUploads(catalogId);
        }

        public Task<UploadListResponse> ListUploads(string catalogId, int maxResults)
        {
            return Client.ListUploads(catalogId, maxResults);
        }

        public Task<UploadListResponse> ListUploads(string catalogId, int maxResults, string nextToken)
        {
            return Client.ListUploads(catalogId, maxResults, nextToken);
        }
    }
}
