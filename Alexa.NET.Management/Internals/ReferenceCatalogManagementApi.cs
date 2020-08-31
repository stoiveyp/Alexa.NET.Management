using System.Net.Http;
using Alexa.NET.Management.Internals;
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
    }
}
