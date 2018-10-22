using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Package;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public class SkillPackageApi:ISkillPackageApi
    {
        private IClientSkillPackageApi Client { get; }

        public SkillPackageApi(HttpClient client)
        {
            Client = RestService.For<IClientSkillPackageApi>(client);
        }

        public Task<PackageUploadMetadata> CreateUpload()
        {
            return Client.CreateUpload();
        }
    }
}
