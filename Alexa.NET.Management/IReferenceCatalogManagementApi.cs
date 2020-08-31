using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.ReferenceCatalogManagement;

namespace Alexa.NET.Management
{
    public interface IReferenceCatalogManagementApi
    {
        public Task<ReferenceCatalogCreationResponse> Create(string vendorId, string name, string description = null);

        public Task<Uri> CreateVersion(string catalogId, string url, string description = null);

        public Task<ReferenceCatalogUpdateStatus> GetUpdateStatus(string catalogId, string updateRequestId);
    }
}
