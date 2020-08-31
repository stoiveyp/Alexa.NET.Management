using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Refit;

namespace Alexa.NET.Management
{
    internal class ReferenceCatalogManagementApi:IReferenceCatalogManagementApi
    {
        public ReferenceCatalogManagementApi(HttpClient httpClient)
        {
            Client = RestService.For<IClientReferenceCatalogManagementApi>(httpClient, ManagementRefitSettings.Create());
        }

        public IClientReferenceCatalogManagementApi Client { get; set; }
        public Task<ReferenceCatalogCreationResponse> Create(string vendorId, string name, string description = null)
        {
            return Client.Create(new ReferenceCatalogCreationRequest
            {
                VendorId = vendorId,
                Catalog = new ReferenceCatalog
                {
                    Name = name,
                    Description = description
                }
            });
        }

        public async Task<Uri> CreateVersion(string catalogId, string url, string description = null)
        {
            var response = await Client.CreateVersion(catalogId, new ReferenceCatalogCreateVersionRequest
            {
                Source = new ReferenceCatalogCreateVersionRequestSource
                {
                    Url = url
                },
                Description = description
            });

            return await response.UriOrError(HttpStatusCode.Accepted);
        }

        public Task<ReferenceCatalogUpdateStatus> GetUpdateStatus(string catalogId, string updateRequestId)
        {
            return Client.GetUpdateStatus(catalogId, updateRequestId);
        }
    }
}
