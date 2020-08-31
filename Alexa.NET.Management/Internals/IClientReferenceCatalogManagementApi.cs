using System;
using System.Collections.Generic;
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
    }
}
