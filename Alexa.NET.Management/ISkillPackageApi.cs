using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Package;

namespace Alexa.NET.Management
{
    public interface ISkillPackageApi
    {
        Task<PackageUploadMetadata> CreateUpload();
        Task<Uri> CreatePackage(string vendorId, string location);
        Task<Uri> CreatePackage(CreatePackageRequest request);

        Task<Uri> CreateSkillPackage(string skillId, string location);

        Task<ImportStatusResponse> SkillPackageStatus(string importId);

        Task<Uri> CreateExportRequest(string skillId, SkillStage stage);
    }
}
