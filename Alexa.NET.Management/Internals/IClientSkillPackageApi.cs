using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Package;
using Refit;

namespace Alexa.NET.Management.Internals
{
    //https://developer.amazon.com/docs/smapi/skill-package-api-reference.html
    public interface IClientSkillPackageApi
    {
        [Post("/skills/uploads")]
        Task<HttpResponseMessage> CreateUpload();

        [Post("/skills/imports")]
        Task<HttpResponseMessage> CreatePackage(CreatePackageRequest request);

        [Post("/skills/{skillId}/imports")]
        Task<HttpResponseMessage> CreateSkillPackage(string skillId,CreateSkillPackageRequest request);
    }
}
