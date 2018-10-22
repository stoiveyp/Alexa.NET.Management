using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Package;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillPackageApi
    {
        [Post("/skills/uploads")]
        Task<PackageUploadMetadata> CreateUpload();
    }
}
