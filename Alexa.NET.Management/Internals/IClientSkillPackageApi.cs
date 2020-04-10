using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Package;
using Refit;

namespace Alexa.NET.Management.Internals
{
    //https://developer.amazon.com/docs/smapi/skill-package-api-reference.html
    public interface IClientSkillPackageApi
    {
        [Post("/v1/skills/uploads")]
        Task<HttpResponseMessage> CreateUpload();

        [Post("/v1/skills/imports")]
        Task<HttpResponseMessage> CreatePackage(CreatePackageRequest request);

        [Post("/v1/skills/{skillId}/imports")]
        Task<HttpResponseMessage> CreateSkillPackage(string skillId,CreateSkillPackageRequest request);

        [Get("/v1/skills/imports/{importId}")]
        Task<ImportStatusResponse> SkillPackageStatus(string importId);

        [Post("/v1/skills/{skillId}/stages/{stage}/exports")]
        Task<HttpResponseMessage> CreateExportRequest(string skillId, SkillStage stage);

        [Get("/v1/skills/exports/{exportId}")]
        Task<ExportStatusResponse> ExportStatus(string exportId);
    }
}
