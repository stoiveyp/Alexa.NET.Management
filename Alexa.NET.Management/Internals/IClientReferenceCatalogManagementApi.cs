using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;
using Refit;

namespace Alexa.NET.Management.Internals
{
    internal interface IClientReferenceCatalogManagementApi
    {
        [Post("/v1/skills/api/custom/interactionModel/catalogs")]
        public Task<ReferenceCatalogCreationResponse> Create(ReferenceCatalogCreationRequest request);

        [Post("/skills/api/custom/interactionModel/catalogs/{catalogId}/versions")]
        public Task<HttpResponseMessage> CreateVersion(string catalogId, ReferenceCatalogCreateVersionRequest request);
    }
}
