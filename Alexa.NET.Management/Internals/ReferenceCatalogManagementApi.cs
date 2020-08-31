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
    }
}
