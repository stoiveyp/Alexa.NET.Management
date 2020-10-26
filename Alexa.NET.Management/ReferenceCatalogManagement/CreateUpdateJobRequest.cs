using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class CreateUpdateJobRequest
    {
        public string VendorId { get; set; }

        public IUpdateJobDefinition JobDefinition { get; set; }
    }
}
