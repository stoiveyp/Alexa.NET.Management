using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Package;

namespace Alexa.NET.Management
{
    public interface ISkillPackageApi
    {
        Task<PackageUploadMetadata> CreateUpload();
        Task<Uri> CreatePackage(string vendorId, string uploadPath);
        Task<Uri> CreatePackage(CreatePackageRequest request);
    }
}
